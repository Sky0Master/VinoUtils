using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VinoUtils.ObjectPool
{
	public interface IPooledObject
	{
		void OnRequestedFromPool();
		void DiscardToPool();
	}
}



