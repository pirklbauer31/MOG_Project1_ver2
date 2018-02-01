﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EventAggregator
{
    private readonly object lockObj = new object();
    private Dictionary<Type, IList> subscriber;
    private static EventAggregator agg;
    public static EventAggregator SingletionAggregator
    {
        get
        {
            if (agg == null)
                agg = new EventAggregator();
            return agg;
        }
    }
    public EventAggregator()
    {
        subscriber = new Dictionary<Type, IList>();
    }

    public void Publish<TMessageType>(TMessageType message)
    {
        Type t = typeof(TMessageType);
        IList sublst;
        if (subscriber.ContainsKey(t))
        {
            lock (lockObj)
            {
                sublst = new List<Subscription<TMessageType>>(subscriber[t].Cast<Subscription<TMessageType>>());
            }

            foreach (Subscription<TMessageType> sub in sublst)
            {
                var action = sub.CreatAction();
                if (action != null)
                    action(message);
            }
        }
    }

    public Subscription<TMessageType> Subscribe<TMessageType>(Action<TMessageType> action)
    {
        Type t = typeof(TMessageType);
        IList actionlst;
        var actiondetail = new Subscription<TMessageType>(action, this);

        lock (lockObj)
        {
            if (!subscriber.TryGetValue(t, out actionlst))
            {
                actionlst = new List<Subscription<TMessageType>>();
                actionlst.Add(actiondetail);
                subscriber.Add(t, actionlst);
            }
            else
            {
                actionlst.Add(actiondetail);
            }
        }
        return actiondetail;
    }

    public void UnSbscribe<TMessageType>(Subscription<TMessageType> subscription)
    {
        Type t = typeof(TMessageType);
        if (subscriber.ContainsKey(t))
        {
            lock (lockObj)
            {
                subscriber[t].Remove(subscription);
            }
            subscription = null;
        }
    }

}