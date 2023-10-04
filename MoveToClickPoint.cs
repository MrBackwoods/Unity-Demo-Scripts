    using UnityEngine;
    using UnityEngine.AI;
    
    // This object moves to the clicked point on the navmesh
    public class MoveToClickPoint : MonoBehaviour
     {
        NavMeshAgent agent;
        public bool DebugLogging;
        
        void Start() 
        {
            agent = GetComponent<NavMeshAgent>();
        }
        
        void Update() 
        {
            if (Input.GetMouseButtonDown(0)) 
            {                
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100)) 
                {
                    AppManager.DebugLog("New destination for object " + this.name + " is " + hit.point.ToString());
                    agent.destination = hit.point;
                }
            }
        }
    }