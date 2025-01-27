﻿using UnityEngine;
using System.Collections;

namespace SmartSpawn {
	
	
	public class SmartSpawnScriptDefaultNetworked : SmartSpawnScript {
		
		protected override void GetReferences ()
		{		
			base.GetReferences();



			#if SS_USEPHOTON && !SS_USEBOLT
			if(PhotonNetwork.isMasterClient == true)
			{
				enabled = true;
			} else {
				#if SS_AUTH
				Debug.LogWarning("Spawner not on master client - Destroying spawner on this client");
				Destroy(this.gameObject);
				#endif
			}
			#endif

			#if !SS_USEPHOTON && SS_USEBOLT
			if(BoltNetwork.isServer == true)
			{
				enabled = true;
			} else {
				#if SS_AUTH
				Debug.LogWarning("Spawner not on server - Destroying spawner on this client");
				Destroy(this.gameObject);
				#endif
			}
			#endif
		}
		
		protected override void SpawnItem(Vector3 spawnLocation, int index) {
			
			//Create the item at the point of the location variable after casting it
			//and make sure it is not null
			GameObject _gameObject = spawnObject.itemPrefab[index] as GameObject;
			
			if(_gameObject != null){

				//Here is where the actual instantiation happens. Remember to define whatever networking system you're using by adding
				// SS_USEPHOTON for photon, SS_USEBOLT for Bolt to your project scripting define symbols (in Player Settings)
		

				#if SS_USEPHOTON && !SS_USEBOLT
				GameObject newItem = PhotonNetwork.Instantiate(_gameObject.name, spawnLocation, _gameObject.transform.rotation, 0) as GameObject;
				#endif

				#if !SS_USEPHOTON && SS_USEBOLT
				BoltEntity newItem = BoltNetwork.Instantiate(_gameObject, spawnLocation, _gameObject.transform.rotation);
				#endif

			
				
				//Output to debug
				//Debug.Log("Spawning " + _gameObject.name.ToString() + " at spawn point " + index.ToString());
			}
			
			if(_gameObject == null){
				Debug.Log("The object you are trying to spawn has not been set.");
			}
			
			maxSpawnerSpawns --;//Decrease the max spawns this spawner can do
		}
		
	}
	
}