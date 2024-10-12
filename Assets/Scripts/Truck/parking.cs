using UnityEngine;

public class parking : MonoBehaviour
{
    // Define all slot variables as static
    private static Vector3 slot0 = new Vector3(553f, 0.1f, 554f);
    private static Vector3 slot1 = new Vector3(559f, 0.1f, 554f);
    private static Vector3 slot2 = new Vector3(565f, 0.1f, 554f);
    private static Vector3 slot3 = new Vector3(570f, 0.1f, 554f);
    private static Vector3 slot4 = new Vector3(576f, 0.1f, 554f);
    private static Vector3 slot5 = new Vector3(582f, 0.1f, 554f);
    private static Vector3 slot6 = new Vector3(587f, 0.1f, 554f);
    private static Vector3 slot7 = new Vector3(593f, 0.1f, 554f);
    private static Vector3 slot8 = new Vector3(621f, 0.1f, 533f);
    private static Vector3 slot9 = new Vector3(616f, 0.1f, 533f);
    private static Vector3 slot10 = new Vector3(610f, 0.1f, 533f);
    private static Vector3 slot11 = new Vector3(604f, 0.1f, 533f);
    private static Vector3 slot12 = new Vector3(598f, 0.1f, 533f);
    private static Vector3 slot13 = new Vector3(592f, 0.1f, 533f);
    private static Vector3 slot14 = new Vector3(585f, 0.1f, 533f);
    private static Vector3 slot15 = new Vector3(579f, 0.1f, 533f);
    private static Vector3 slot16 = new Vector3(573f, 0.1f, 533f);
    private static Vector3 slot17 = new Vector3(567f, 0.1f, 533f);
    private static Vector3 slot18 = new Vector3(561f, 0.1f, 533f);
    private static Vector3 slot19 = new Vector3(556f, 0.1f, 533f);
    private static Vector3 slot20 = new Vector3(550f, 0.1f, 533f);
    private static Vector3 slot21 = new Vector3(544f, 0.1f, 533f);
    private static Vector3 slot22 = new Vector3(538f, 0.1f, 533f);

    // Start is called before the first frame update
    void Start()
    {

    }

    public static void park(string name)
    {
        GameObject Truck = GameObject.Find(name);

        if (Truck != null)
        {
            // Check slot0
            GameObject slot0Obj = GameObject.Find("parking 0");
            if (slot0Obj != null && slot0Obj.CompareTag("empty"))
            {
                Truck.transform.position = slot0;
                slot0Obj.tag = "full";
                return;
            }

            // Check slot1
            GameObject slot1Obj = GameObject.Find("parking 1");
            if (slot1Obj != null && slot1Obj.CompareTag("empty"))
            {
                Truck.transform.position = slot1;
                slot1Obj.tag = "full";
                return;
            }

            // Check slot2
            GameObject slot2Obj = GameObject.Find("parking 2");
            if (slot2Obj != null && slot2Obj.CompareTag("empty"))
            {
                Truck.transform.position = slot2;
                slot2Obj.tag = "full";
                return;
            }

            // Continue adding checks for all other slots...
            GameObject slot3Obj = GameObject.Find("parking 3");
            if (slot3Obj != null && slot3Obj.CompareTag("empty"))
            {
                Truck.transform.position = slot3;
                slot3Obj.tag = "full";
                return;
            }

            GameObject slot4Obj = GameObject.Find("parking 4");
            if (slot4Obj != null && slot4Obj.CompareTag("empty"))
            {
                Truck.transform.position = slot4;
                slot4Obj.tag = "full";
                return;
            }

            GameObject slot5Obj = GameObject.Find("parking 5");
            if (slot5Obj != null && slot5Obj.CompareTag("empty"))
            {
                Truck.transform.position = slot5;
                slot5Obj.tag = "full";
                return;
            }

            GameObject slot6Obj = GameObject.Find("parking 6");
            if (slot6Obj != null && slot6Obj.CompareTag("empty"))
            {
                Truck.transform.position = slot6;
                slot6Obj.tag = "full";
                return;
            }

            GameObject slot7Obj = GameObject.Find("parking 7");
            if (slot7Obj != null && slot7Obj.CompareTag("empty"))
            {
                Truck.transform.position = slot7;
                slot7Obj.tag = "full";
                return;
            }

            GameObject slot8Obj = GameObject.Find("parking 8");
            if (slot8Obj != null && slot8Obj.CompareTag("empty"))
            {
                Truck.transform.position = slot8;
                slot8Obj.tag = "full";
                return;
            }

            GameObject slot9Obj = GameObject.Find("parking 9");
            if (slot9Obj != null && slot9Obj.CompareTag("empty"))
            {
                Truck.transform.position = slot9;
                slot9Obj.tag = "full";
                return;
            }

            GameObject slot10Obj = GameObject.Find("parking 10");
            if (slot10Obj != null && slot10Obj.CompareTag("empty"))
            {
                Truck.transform.position = slot10;
                slot10Obj.tag = "full";
                return;
            }

            GameObject slot11Obj = GameObject.Find("parking 11");
            if (slot11Obj != null && slot11Obj.CompareTag("empty"))
            {
                Truck.transform.position = slot11;
                slot11Obj.tag = "full";
                return;
            }

            GameObject slot12Obj = GameObject.Find("parking 12");
            if (slot12Obj != null && slot12Obj.CompareTag("empty"))
            {
                Truck.transform.position = slot12;
                slot12Obj.tag = "full";
                return;
            }

            GameObject slot13Obj = GameObject.Find("parking 13");
            if (slot13Obj != null && slot13Obj.CompareTag("empty"))
            {
                Truck.transform.position = slot13;
                slot13Obj.tag = "full";
                return;
            }

            GameObject slot14Obj = GameObject.Find("parking 14");
            if (slot14Obj != null && slot14Obj.CompareTag("empty"))
            {
                Truck.transform.position = slot14;
                slot14Obj.tag = "full";
                return;
            }

            GameObject slot15Obj = GameObject.Find("parking 15");
            if (slot15Obj != null && slot15Obj.CompareTag("empty"))
            {
                Truck.transform.position = slot15;
                slot15Obj.tag = "full";
                return;
            }

            GameObject slot16Obj = GameObject.Find("parking 16");
            if (slot16Obj != null && slot16Obj.CompareTag("empty"))
            {
                Truck.transform.position = slot16;
                slot16Obj.tag = "full";
                return;
            }

            GameObject slot17Obj = GameObject.Find("parking 17");
            if (slot17Obj != null && slot17Obj.CompareTag("empty"))
            {
                Truck.transform.position = slot17;
                slot17Obj.tag = "full";
                return;
            }

            GameObject slot18Obj = GameObject.Find("parking 18");
            if (slot18Obj != null && slot18Obj.CompareTag("empty"))
            {
                Truck.transform.position = slot18;
                slot18Obj.tag = "full";
                return;
            }

            GameObject slot19Obj = GameObject.Find("parking 19");
            if (slot19Obj != null && slot19Obj.CompareTag("empty"))
            {
                Truck.transform.position = slot19;
                slot19Obj.tag = "full";
                return;
            }

            GameObject slot20Obj = GameObject.Find("parking 20");
            if (slot20Obj != null && slot20Obj.CompareTag("empty"))
            {
                Truck.transform.position = slot20;
                slot20Obj.tag = "full";
                return;
            }

            GameObject slot21Obj = GameObject.Find("parking 21");
            if (slot21Obj != null && slot21Obj.CompareTag("empty"))
            {
                Truck.transform.position = slot21;
                slot21Obj.tag = "full";
                return;
            }

            GameObject slot22Obj = GameObject.Find("parking 22");
            if (slot22Obj != null && slot22Obj.CompareTag("empty"))
            {
                Truck.transform.position = slot22;
                slot22Obj.tag = "full";
                return;
            }

            Debug.Log("No empty slots available.");
        }
        else
        {
            Debug.Log("Truck not found");
        }
    }



    public static bool haveEmptySlot()
    {
            // Check slot0
            GameObject slot0Obj = GameObject.Find("parking 0");
            if (slot0Obj != null && slot0Obj.CompareTag("empty"))
            {
                return true;
            }

            // Check slot1
            GameObject slot1Obj = GameObject.Find("parking 1");
            if (slot1Obj != null && slot1Obj.CompareTag("empty"))
            {
            return true;
            }

            // Check slot2
            GameObject slot2Obj = GameObject.Find("parking 2");
            if (slot2Obj != null && slot2Obj.CompareTag("empty"))
            {
            return true;
            }

            // Continue adding checks for all other slots...
            GameObject slot3Obj = GameObject.Find("parking 3");
            if (slot3Obj != null && slot3Obj.CompareTag("empty"))
            {
            return true;
            }

            GameObject slot4Obj = GameObject.Find("parking 4");
            if (slot4Obj != null && slot4Obj.CompareTag("empty"))
            {
            return true;
            }

            GameObject slot5Obj = GameObject.Find("parking 5");
            if (slot5Obj != null && slot5Obj.CompareTag("empty"))
            {
                return true;
            }

            GameObject slot6Obj = GameObject.Find("parking 6");
            if (slot6Obj != null && slot6Obj.CompareTag("empty"))
            {
            return true;
            }

            GameObject slot7Obj = GameObject.Find("parking 7");
            if (slot7Obj != null && slot7Obj.CompareTag("empty"))
            {
                return true;
            }

            GameObject slot8Obj = GameObject.Find("parking 8");
            if (slot8Obj != null && slot8Obj.CompareTag("empty"))
            {
                return true;
            }

            GameObject slot9Obj = GameObject.Find("parking 9");
            if (slot9Obj != null && slot9Obj.CompareTag("empty"))
            {
                return true;
            }

            GameObject slot10Obj = GameObject.Find("parking 10");
            if (slot10Obj != null && slot10Obj.CompareTag("empty"))
            {
                return true;
            }

            GameObject slot11Obj = GameObject.Find("parking 11");
            if (slot11Obj != null && slot11Obj.CompareTag("empty"))
            {
                return true;
            }

            GameObject slot12Obj = GameObject.Find("parking 12");
            if (slot12Obj != null && slot12Obj.CompareTag("empty"))
            {
                return true;
            }

            GameObject slot13Obj = GameObject.Find("parking 13");
            if (slot13Obj != null && slot13Obj.CompareTag("empty"))
            {
                return true;
            }

            GameObject slot14Obj = GameObject.Find("parking 14");
            if (slot14Obj != null && slot14Obj.CompareTag("empty"))
            {
                return true;
            }

            GameObject slot15Obj = GameObject.Find("parking 15");
            if (slot15Obj != null && slot15Obj.CompareTag("empty"))
            {
                return true;
            }

            GameObject slot16Obj = GameObject.Find("parking 16");
            if (slot16Obj != null && slot16Obj.CompareTag("empty"))
            {
                return true;
            }

            GameObject slot17Obj = GameObject.Find("parking 17");
            if (slot17Obj != null && slot17Obj.CompareTag("empty"))
            {
                return true;
            }

            GameObject slot18Obj = GameObject.Find("parking 18");
            if (slot18Obj != null && slot18Obj.CompareTag("empty"))
            {
                return true;
            }

            GameObject slot19Obj = GameObject.Find("parking 19");
            if (slot19Obj != null && slot19Obj.CompareTag("empty"))
            {
                return true;
            }

            GameObject slot20Obj = GameObject.Find("parking 20");
            if (slot20Obj != null && slot20Obj.CompareTag("empty"))
            {
                return true;
            }

            GameObject slot21Obj = GameObject.Find("parking 21");
            if (slot21Obj != null && slot21Obj.CompareTag("empty"))
            {
                return true;
            }

            GameObject slot22Obj = GameObject.Find("parking 22");
            if (slot22Obj != null && slot22Obj.CompareTag("empty"))
            {
                return true;
            } else
        {
            return false;
        }

            
      
    }



    // Update is called once per frame
    void Update()
    {

    }
}
