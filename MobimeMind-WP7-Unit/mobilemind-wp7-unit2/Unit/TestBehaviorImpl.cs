using System.Collections.Generic;
using System;


namespace MobileMindWP7Unit.Unit
{

    /// <summary>
    /// 
    /// </summary>
    public abstract class TestBehaviorImpl : ITestBehavior
    {

        private IList<String> message = new List<String>();

        public virtual void SetUp()
        {
        }

        public virtual void SetUpClass()
        {
        }

        public virtual void TearDown()
        {
        }

        public virtual void TearDownClass()
        {
        }

        public virtual void Say(String message)
        {
            this.message.Add(message);
        }

        public virtual void ClearMessages()
        {
            this.message.Clear();
        }

        public virtual IList<String> GetMessage()
        {
            return message;
        }
    }
}