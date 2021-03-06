﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mid.Tools
{
    public static class ThreadTools
    {

        public delegate void MethodToTry();

        public static void DelayMethod(TimeSpan startDelay, MethodToTry methodToDo)
        {
            Task.Delay((int)startDelay.TotalMilliseconds).Wait();

            methodToDo();

        }

        public static void TryMethodManyTimes(int maxTry, TimeSpan sleepBetweenTries,MethodToTry methodToTry)
        {
            bool hasSucceeded = false;
            int nbTry = 0;
            do
            {
                try
                {
                    methodToTry();
                    hasSucceeded = true;
                }
                catch (Exception ex)
                {
                    hasSucceeded = false;

                    if (nbTry >= maxTry-1)
                    {
                        throw ex;
                    }
                    Task.Delay(sleepBetweenTries).Wait();
                }
                finally
                {
                    nbTry++;
                }
            }
            while (nbTry < maxTry && hasSucceeded == false);
        }


        public static void TryDBMethodManyTimes(int maxTry, TimeSpan sleepBetweenTries, MethodToTry methodToTry)
        {
            bool hasSucceeded = false;
            int nbTry = 0;
            do
            {
                try
                {
                    methodToTry();
                    hasSucceeded = true;
                }
                catch (Exception ex)
                {
                    hasSucceeded = false;

                    if (nbTry >= maxTry - 1)
                    {
                        throw ex;
                    }
                    Task.Delay(sleepBetweenTries).Wait();
                }
                finally
                {
                    nbTry++;
                }
            }
            while (nbTry < maxTry && hasSucceeded == false);
        }
    }
}
