public static class DependencyObjectExtensions
    {
        public static T FindParent<T>(this DependencyObject source) where T : DependencyObject
        {
		  while (source != null && !(source is T))
			  source = VisualTreeHelper.GetParent(source);

		  return source as T;
        }

        public static T FindParent<T>(this DependencyObject source, Predicate<T> parentMatch) where T: class
        {
           
            while (source != null)
            {
                if (source is T && parentMatch((T)(object)source))
                {
                    return (T)(object)source;
                }
                source = VisualTreeHelper.GetParent(source);
            }

            return null;
        }
        public static T FindLogicalParent<T>(this DependencyObject source, Predicate<T> parentMatch) where T : class
        {

            while (source != null)
            {
                if (source is T && parentMatch((T)(object)source))
                {
                    return (T)(object)source;
                }
                source = LogicalTreeHelper.GetParent(source);
            }

            return null;
        }
        public static IRegionManager GetRegionManager(this DependencyObject source)
        {
            UIElement regionParent = source.FindLogicalParent<UIElement>((elem) =>
                RegionManager.GetRegionManager(elem) != null);
            if (regionParent == null)
            {
                return null;
            }
            return RegionManager.GetRegionManager(regionParent);
        }
        public static T FindChildDepthFirst<T>(this DependencyObject source) where T : DependencyObject
        {
            return FindChildDepthFirst<T>(source, t => true);
        }

        public static T FindChildDepthFirst<T>(this DependencyObject source, Predicate<T> pred) where T : DependencyObject
        {
            Stack<DependencyObject> s = new Stack<DependencyObject>();
            s.Push(source);

            while (s.Count > 0)
            {
                DependencyObject d = s.Pop();
                if (d is T && pred((T)d))
                    return (T)d;

                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(d); i++)
                {
                    s.Push(VisualTreeHelper.GetChild(d, i));
                }
            }
            return null;
        }

        public static T FindChildBreadthFirst<T>(this DependencyObject source) where T : DependencyObject
        {
            return FindChildBreadthFirst<T>(source, t => true);
        }

        public static T FindChildBreadthFirst<T>(this DependencyObject source, Predicate<T> pred) where T : DependencyObject
        {
            Queue<DependencyObject> q = new Queue<DependencyObject>();
            q.Enqueue(source);

            while (q.Count > 0)
            {
                DependencyObject d = q.Dequeue();
                if (d is T && pred((T)d))
                    return (T)d;

                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(d); i++)
                {
                    q.Enqueue(VisualTreeHelper.GetChild(d, i));
                }
            }
            return null;
        }
    }
