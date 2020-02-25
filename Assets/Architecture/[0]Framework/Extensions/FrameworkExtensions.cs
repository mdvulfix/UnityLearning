/*===============================================================
Product:    Battlecruiser
Developer:  Dimitry Pixeye - pixeye@hbrew.store
Company:    Homebrew - http://hbrew.store
Date:       12/09/2017 23:42
================================================================*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Homebrew
{
    public static partial class FrameworkExtensions
    {
        private static System.Random _r = new System.Random();

     
       

        public static Actor GetEntity(this object o, int id)
        {
            return Actor.entites[id];
        }

        public static T Add<T>(this MonoCached mono) where T : class, new()
        {
            return mono.actorParent.Add<T>();
        }

        public static T DeepClone<T>(this T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T) formatter.Deserialize(ms);
            }
        }


        #region 2dRaycasts

//        public static Actor GetActor(this RaycastHit2D hit, params int[] tags)
//        {
//            var o = hit.collider.GetComponentInParent<MonoCached>();
//            if (o == null) return null;
//            var entity = o.actorParent;
//            if (entity == null) return null;
//            return entity.HasAllTags(tags) ? entity : null;
//        }

        public static Actor GetActor(this RaycastHit2D hit, params int[] tags)
        {
            var actor = hit.collider.GetComponentInParent<Actor>();
            if (actor == null) return null;
            if (actor.tags == null) return null;
            return actor.HasTags(tags) ? actor : null;
        }


//		public static bool HasTag(this RaycastHit2D o, int tag)
//		{
//			var componentTags = o.collider.GetComponent<ComponentTag>();
//			if (componentTags == null) return false;
//			return componentTags.CanBeObserved(tag);
//		}
//
//
//		public static actor GetActor(this RaycastHit2D o, int id)
//		{
//			var componentTags = o.collider.GetComponent<ComponentTag>();
//			if (componentTags == null) return null;
//
//
//			for (var i = 0; i < componentTags.tags.Count; i++)
//			{
//				var t = componentTags.tags[i];
//				if (t.id == id)
//				{
//					var actor = componentTags.GetComponentInParent<actor>();
//					return actor;
//				}
//			}
//
//			return null;
//		}
//
//		public static bool IsDesiredActor(this actor a, params int[] id)
//		{
//			if (a == null) return false;
//			return a.tags.ContainAll(id);
//		}
//
//
//		public static actor GetActor(this RaycastHit2D o, List<DataTag> colliderTags)
//		{
//			var componentTags = o.collider.GetComponent<ComponentTag>();
//			if (componentTags == null) return null;
//
//
//			for (var i = 0; i < componentTags.tags.Count; i++)
//			{
//				var t = componentTags.tags[i];
//				for (int j = 0; j < colliderTags.Count; j++)
//				{
//					if (t.id == colliderTags[j].id) return componentTags.GetComponentInParent<actor>();
//				}
//			}
//
//			return null;
//		}
//
//		public static ComponentTag CanBeObserved(this RaycastHit2D o, List<DataTag> colliderTags)
//		{
//			var componentTags = o.collider.GetComponent<ComponentTag>();
//			if (componentTags == null) return null;
//
//			for (var i = 0; i < componentTags.tags.Count; i++)
//			{
//				var t = componentTags.tags[i];
//
//				for (int j = 0; j < colliderTags.Count; j++)
//				{
//					if (t.id == colliderTags[j].id) return componentTags;
//				}
//			}
//
//			return null;
//		}
//
//		public static bool IsHittable(this actor target, List<DataTag> hittables)
//		{
//			for (var i = 0; i < hittables.Count; i++)
//			{
//				if (target.tags.Contain(hittables[i].id)) return true;
//			}
//
//			return false;
//		}
//
//
//		public static bool HasTag(this Collider2D o, int tag)
//		{
//			var componentTags = o.GetComponent<ComponentTag>();
//			if (componentTags == null) return false;
//			return componentTags.CanBeObserved(tag);
//		}
//
//
//		public static actor GetActor(this Collider2D o, int id)
//		{
//			var componentTags = o.GetComponent<ComponentTag>();
//			if (componentTags == null) return null;
//
//
//			for (var i = 0; i < componentTags.tags.Count; i++)
//			{
//				var t = componentTags.tags[i];
//				if (t.id == id)
//				{
//					var actor = componentTags.GetComponentInParent<actor>();
//					return actor;
//				}
//			}
//
//			return null;
//		}
//
//		public static actor GetActor(this Collider2D o, List<DataTag> colliderTags)
//		{
//			if (o == null || o.enabled == false) return null;
//			var componentTags = o.GetComponent<ComponentTag>();
//			if (componentTags == null) return null;
//
//
//			for (var i = 0; i < componentTags.tags.Count; i++)
//			{
//				var t = componentTags.tags[i];
//				for (int j = 0; j < colliderTags.Count; j++)
//				{
//					if (t.id == colliderTags[j].id) return componentTags.GetComponentInParent<actor>();
//				}
//			}
//
//			return null;
//		}
//
//		public static ComponentTag CanBeObserved(this Collider2D o, List<DataTag> colliderTags)
//		{
//			if (o == null) return null;
//			var componentTags = o.GetComponent<ComponentTag>();
//			if (componentTags == null) return null;
//
//			for (var i = 0; i < componentTags.tags.Count; i++)
//			{
//				var t = componentTags.tags[i];
//
//				for (int j = 0; j < colliderTags.Count; j++)
//				{
//					if (t.id == colliderTags[j].id) return componentTags;
//				}
//			}
//
//			return null;
//		}

        #endregion

        public static int Between(this object o, int a, int b, float chance = 0.5f)
        {
            return UnityEngine.Random.value > chance ? a : b;
        }

        public static float Between(this object o, float a, float b, float chance = 0.5f)
        {
            return UnityEngine.Random.value > chance ? a : b;
        }


        #region OLD

        public static float ClampAngle(this float angle, float min, float max)
        {
            if (min < 0 && max > 0 && (angle > max || angle < min))
            {
                angle -= 360;
                if (angle > max || angle < min)
                {
                    return Mathf.Abs(Mathf.DeltaAngle(angle, min)) < Mathf.Abs(Mathf.DeltaAngle(angle, max))
                        ? min
                        : max;
                }
            }
            else if (min > 0 && (angle > max || angle < min))
            {
                angle += 360;
                if (angle > max || angle < min)
                {
                    return Mathf.Abs(Mathf.DeltaAngle(angle, min)) < Mathf.Abs(Mathf.DeltaAngle(angle, max))
                        ? min
                        : max;
                }
            }

            if (angle < min) return min;
            else if (angle > max)
                return max;
            else
                return angle;
        }

        public static int ReturnNearestIndex(this Vector3[] nodes, Vector3 destination)
        {
            var nearestDistance = Mathf.Infinity;
            var index = 0;
            var length = nodes.Length;
            for (var i = 0; i < length; i++)
            {
                var distanceToNode = (destination + nodes[i]).sqrMagnitude;
                if (!(nearestDistance > distanceToNode)) continue;
                nearestDistance = distanceToNode;
                index = i;
            }

            return index;
        }

        public static T ReturnRandom<T>(this List<T> list, T[] itemsToExclude)
        {
            var val = list[UnityEngine.Random.Range(0, list.Count)];

            while (itemsToExclude.Contains(val))
                val = list[UnityEngine.Random.Range(0, list.Count)];

            return val;
        }

        public static T ReturnRandom<T>(this List<T> list)
        {
            var val = list[UnityEngine.Random.Range(0, list.Count)];
            return val;
        }

        public static T GetRandom<T>(this List<T> vals) where T : IRandom
        {
            var total = 0f;

            var probs = new float[vals.Count];


            for (var i = 0; i < probs.Length; i++)
            {
                probs[i] = vals[i].returnChance;
                total += probs[i];
            }


            var randomPoint = (float) _r.NextDouble() * total;


            for (var i = 0; i < probs.Length; i++)
            {
                if (randomPoint < probs[i])
                    return vals[i];
                randomPoint -= probs[i];
            }

            return vals[0];
        }

        public static T GetRandom<T>(this T[] vals) where T : IRandom
        {
            if (vals == null || vals.Length == 0) return default(T);


            float total = 0f;

            float[] probs = new float[vals.Length];


            for (int i = 0; i < probs.Length; i++)
            {
                probs[i] = vals[i].returnChance;
                total += probs[i];
            }


            float randomPoint = (float) _r.NextDouble() * total;


            for (int i = 0; i < probs.Length; i++)
            {
                if (randomPoint < probs[i])
                    return vals[i];
                else randomPoint -= probs[i];
            }

            return vals[0];
        }

        public static float GetRandomArg(this float[] vals)
        {
            if (vals == null || vals.Length == 0) return -1;


            var total = 0f;

            var probs = new float[vals.Length];


            for (var i = 0; i < probs.Length; i++)
            {
                probs[i] = vals[i];
                total += probs[i];
            }


            var randomPoint = (float) _r.NextDouble() * total;


            for (var i = 0; i < probs.Length; i++)
            {
                if (randomPoint < probs[i])
                    return probs[i];
                randomPoint -= probs[i];
            }

            return 0;
        }


        public static int GetRandom(this float[] vals)
        {
            if (vals == null || vals.Length == 0) return -1;


            var total = 0f;

            var probs = new float[vals.Length];


            for (var i = 0; i < probs.Length; i++)
            {
                probs[i] = vals[i];
                total += probs[i];
            }


            var randomPoint = (float) _r.NextDouble() * total;


            for (var i = 0; i < probs.Length; i++)
            {
                if (randomPoint < probs[i])
                    return i;
                randomPoint -= probs[i];
            }

            return 0;
        }

        public static T Random<T>(this T[] vals)
        {
            return vals[UnityEngine.Random.Range(0, vals.Length)];
        }

        public static T RandomList<T>(this List<T> vals)
        {
            return vals[UnityEngine.Random.Range(0, vals.Count)];
        }

        public static T RandomWithRemove<T>(this List<T> vals)
        {
            var index = UnityEngine.Random.Range(0, vals.Count);
            var val = vals[index];
            vals.RemoveAt(index);
            return val;
        }


        public static T GetRandom<T>(this T[] vals, out int index) where T : IRandom
        {
            index = -1;

            if (vals == null || vals.Length == 0) return default(T);


            float total = 0f;

            float[] probs = new float[vals.Length];


            for (int i = 0; i < probs.Length; i++)
            {
                probs[i] = vals[i].returnChance;
                total += probs[i];
            }


            var randomPoint = (float) _r.NextDouble() * total;


            for (var i = 0; i < probs.Length; i++)
            {
                if (randomPoint < probs[i])
                {
                    index = i;
                    return vals[i];
                }

                randomPoint -= probs[i];
            }

            return vals[0];
        }

        public static T GetRandom<T>(this T[] vals, float[] probs) where T : IRandom
        {
            if (vals == null || vals.Length == 0) return default(T);


            var total = probs.Sum();


            var randomPoint = (float) _r.NextDouble() * total;


            for (var i = 0; i < probs.Length; i++)
            {
                if (randomPoint < probs[i])
                    return vals[i];
                randomPoint -= probs[i];
            }

            return vals[0];
        }


        public static float GetRandom(this Vector2 v)
        {
            return UnityEngine.Random.Range(v.x, v.y);
        }

        public static float GetRandomChoice(this Vector2 v)
        {
            return UnityEngine.Random.value >= 0.5f ? v.x : v.y;
        }


        public static Vector3 MixRandom(this Vector3 me, Vector3 v1, Vector3 v2)
        {
            var v = new Vector3(
                UnityEngine.Random.Range(v1.x, v2.x),
                UnityEngine.Random.Range(v1.y, v2.y),
                UnityEngine.Random.Range(v1.z, v2.z)
            );
            return v;
        }

        public static Vector3 MultiplyX(this Vector3 v, float val)
        {
            v = new Vector3(val * v.x, v.y, v.z);
            return v;
        }

        public static Vector3 MultiplyY(this Vector3 v, float val)
        {
            v = new Vector3(v.x, val * v.y, v.z);
            return v;
        }

        public static Vector3 MultiplyZ(this Vector3 v, float val)
        {
            v = new Vector3(v.x, v.y, val * v.z);
            return v;
        }


        public static T[] Increase<T>(this T[] values, int increment)
        {
            T[] array = new T[values.Length + increment];
            values.CopyTo(array, 0);
            return array;
        }

        public static T[] AddOrPopulate<T>(this T[] array, T val)
        {
            var length = array.Length;

            for (var i = 0; i < length; i++)
            {
                if (array[i] != null) continue;
                array[i] = val;
                return array;
            }

            array = array.Increase(10);
            array[length] = val;
            return array;
        }

        public static T[] Add<T>(this T[] array, T val)
        {
            var length = array.Length;

            array = array.Increase(1);
            array[length] = val;
            return array;
        }


        public static T[] Remove<T>(this T[] source, object obj, ref int amount)
        {
            var index = Array.FindIndex(source, o => o != null && o.Equals(obj));
            if (index == -1)
            {
                return source;
            }

            T[] dest = new T[source.Length - 1];


            if (index > 0)
                Array.Copy(source, 0, dest, 0, index);

            if (index < source.Length - 1)
                Array.Copy(source, index + 1, dest, index, source.Length - index - 1);
            amount--;
            return dest;
        }

        public static T[] RemoveAt<T>(this T[] source, int index)
        {
            T[] dest = new T[source.Length - 1];
            if (index > 0)
                Array.Copy(source, 0, dest, 0, index);

            if (index < source.Length - 1)
                Array.Copy(source, index + 1, dest, index, source.Length - index - 1);

            return dest;
        }

        #endregion


        #region TRANSFORMS

        public static Transform[] GetChildTransfroms(this Transform t)
        {
            var size = t.childCount;
            var array = new Transform[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = t.GetChild(i);
            }

            return array;
        }

        public static Vector3[] GetChildTransfromsPos(this Transform t)
        {
            var size = t.childCount;
            var array = new Vector3[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = t.GetChild(i).position;
            }

            return array;
        }


        public static Vector3 AppendZ(this Transform obj, float zVal = 0.0f)
        {
            return new Vector3(obj.position.x, obj.position.y, zVal);
        }

        public static Vector3 AppendZ(this Vector3 obj, float zVal = 0.0f)
        {
            return new Vector3(obj.x, obj.y, zVal);
        }


        public static Transform FindDeep(this Transform obj, string id)
        {
            if (obj.name == id)
            {
                return obj;
            }

            var count = obj.childCount;
            for (var i = 0; i < count; ++i)
            {
                var posObj = obj.GetChild(i).FindDeep(id);
                if (posObj != null)
                {
                    return posObj;
                }
            }

            return null;
        }


        public static List<T> GetAll<T>(this Transform obj)
        {
            var results = new List<T>();
            obj.GetComponentsInChildren(results);
            return results;
        }

        #endregion

        #region EASE

//		public static float CalculateEase(float time, float duration, Ease ease)
//		{
//			var overshootOrAmplitude = 1.70158f;
//			switch (ease)
//			{
//				case Ease.InSine:
//					return (float) (-Math.Cos(time / (double) duration * 1.57079637050629f) + 1.0);
//				case Ease.OutSine:
//					return (float) Math.Sin(time / (double) duration * 1.57079637050629);
//				case Ease.InBack:
//					return (float) ((time /= duration) * (double) time *
//					                ((overshootOrAmplitude + 1.0) * time - overshootOrAmplitude));
//				case Ease.OutBack:
//					return (float) ((time = (float) (time / (double) duration - 1.0)) * (double) time *
//					                ((overshootOrAmplitude + 1.0) * time + overshootOrAmplitude) + 1.0);
//				case Ease.InOutBack:
//					if ((time /= duration * 0.5f) < 1.0)
//						return (float) (0.5 * (time * (double) time *
//						                       (((overshootOrAmplitude *= 1.525f) + 1.0) * time - overshootOrAmplitude)));
//					return (float) (0.5 * ((time -= 2f) * (double) time *
//					                       (((overshootOrAmplitude *= 1.525f) + 1.0) * time + overshootOrAmplitude) + 2.0));
//				case Ease.InCirc:
//					return (float) -(Math.Sqrt(1.0 - (time /= duration) * (double) time) - 1.0);
//				case Ease.OutCirc:
//					return (float) Math.Sqrt(1.0 - (time = (float) (time / (double) duration - 1.0)) * (double) time);
//				default:
//					return time / duration;
//			}
//		}

        #endregion

        #region COLORS

        public static Color SetColorAlpha(this Color c, float alpha)
        {
            return new Color(c.r, c.g, c.b, alpha);
        }

        #endregion
    }
}