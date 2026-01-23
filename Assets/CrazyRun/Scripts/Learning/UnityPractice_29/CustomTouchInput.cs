using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CustomTouchInput : MonoBehaviour
{
    //public Rigidbody rb;
    //public float speed;

    public float startTimer;

    void Start()
    {
        
    }

    void Update()
    {
        //for (int i = 0; i < Input.touches.Length; i++)                                        }
        //{
        //    Debug.Log("Это касание номер" + i + " с позицией " + Input.touches[i].position);  }  Скрипт автоматичекой регистрации касаний
        //}

        if (Input.touchCount > 0)
        {
            //Debug.Log(Input.touchCount); - touchCount выводит количество зарегестированных одновременно нажатий на экран;

            Touch touch = Input.GetTouch(0);  // GetTouch возвращает данные о Touch с номером индекса нажатия
            //Touch touch2 = Input.GetTouch(1);

            //if (touch.phase == TouchPhase.Began)                                     }
            //{
            //    startTimer = Time.time;                                              } 
            //    Debug.Log("Тап!");                                                   }    Скрипт получения информации о длительном нажатии. У метода TouchPhase следующие параметры: Began, Moved, Stationary, Ended, Cancelled.
            //}
            //if (touch.phase == TouchPhase.Ended && Time.time - startTimer > 2f)      }
            //{
            //    Debug.Log("Длинный инпут получен");                                  }
            //}



            //Vector3 force = new Vector3(touch.position.x, 0f, touch.position.y); }
            //rb.AddForce(force * speed);                                          }  Скрипт активации движения объекта на основе места нажатия на экран;


            if (touch.deltaPosition.x > 0)                                            // }
                Debug.Log("Направо");                                                 // }
            if (touch.deltaPosition.x < 0)                                            // }   Скрипт получения информации о свайпе вправо или влево;
                Debug.Log("Налево");                                                  // }


            //Debug.Log(touch.position); - touch.position выводит координаты касания;    

        }
    }
}
