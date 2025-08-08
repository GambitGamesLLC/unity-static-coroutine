/*******************************************************************
 * StaticCoroutine.cs
 * 
 * Use this class from a non-monobehaviour derived class to give it access to coroutines!
 * https://forum.unity.com/threads/passing-in-a-monobehaviour-to-run-a-coroutine.588049/
 * 
 * Call StaticCoroutine.Start( YourRoutine() );
 * 
 ********************************************************************/
#region IMPORTS

using System.Collections;
using UnityEngine;

#endregion

namespace gambit.staticcoroutine
{
    public class StaticCoroutine
    {
        #region PRIVATE - VARIABLES

        private static StaticCoroutineRunner runner;

        #endregion

        #region PUBLIC - START

        /// <summary>
        /// Starts a coroutine
        /// </summary>
        /// <param name="coroutine"></param>
        /// <returns></returns>
        //---------------------------------------------------------//
        public static Coroutine Start(IEnumerator coroutine)
        //---------------------------------------------------------//
        {
            if (coroutine == null)
            {
                Debug.LogError("StaticCoroutine.cs Start() ERROR: coroutine sent in is null!");
                return null;
            }

            EnsureRunner();
            return runner.StartCoroutine(coroutine);

        } //END Start Method

        #endregion

        #region PUBLIC - STOP

        /// <summary>
        /// Stops a coroutine
        /// </summary>
        /// <param name="coroutine"></param>
        /// <returns></returns>
        //---------------------------------------------------------//
        public static void Stop( Coroutine coroutine )
        //---------------------------------------------------------//
        {
            if(coroutine == null)
            {
                Debug.LogError( "StaticCoroutine.cs Stop() ERROR: coroutine sent in is null!" );
                return;
            }

            EnsureRunner();
            runner.StopCoroutine(coroutine);

        } //END Stop Method


        #endregion

        #region PRIVATE - ENSURE RUNNER EXISTS

        /// <summary>
        /// Make sure the gameobject running the coroutines exists
        /// </summary>
        //------------------------------------------//
        private static void EnsureRunner()
        //------------------------------------------//
        {
            if (runner == null)
            {
                runner = new GameObject("[Static Coroutine Runner]").AddComponent<StaticCoroutineRunner>();
                Object.DontDestroyOnLoad(runner.gameObject);
            }

        } //END EnsureRunner

        #endregion

        #region PRIVATE - STATIC COROUTINE RUNNER - CLASS

        /// <summary>
        /// Empty class used as a component reference
        /// </summary>
        private class StaticCoroutineRunner : MonoBehaviour
        {
        }

        #endregion

    } //END StaticCoroutine Class

} //END gambit.staticcoroutine namespace