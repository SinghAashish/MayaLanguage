
using System;
using System.Collections;
using System.Collections.Generic;

namespace Components
{
	public class Context
	{
		private ArrayList contexts;
			
		public Context()
		{
			contexts = new ArrayList();
		}
		
		public void SetContexts(params Dictionary<string,object>[] contextObjects){
			foreach (Dictionary<string,object> contextObject in contextObjects) {
				this.contexts.Add(contextObject);
			}
		}
		
		public object GetValueOf(string variableName){
			foreach (object contextObject in this.contexts) {
				Dictionary<string,object> context = contextObject as Dictionary<string,object>;
				if (context.ContainsKey(variableName))
					return context[variableName];
			}
			return null;
		}
		
		public void SetValueOf(string variableName,object valueObject){
			((Dictionary<string,object>)contexts[0])[variableName] = valueObject;
		}		
	}
}