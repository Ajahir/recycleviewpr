
using Android.Content;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;

namespace recycleviewpr
{
    internal class Adapter : RecyclerView.Adapter
    {
        public event EventHandler<AdapterClickEventArgs> ItemClick;
        public event EventHandler<AdapterClickEventArgs> ItemLongClick;
        List<datamodal> list;
        Context context;

        public Adapter(List<datamodal> data, Context context)
        {
            list = data;
            this.context = context;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            //Setup your layout here
            View itemView = null;
            var id = Resource.Layout.layout1;
            itemView = LayoutInflater.From(parent.Context).
                 Inflate(id, parent, false);

            var vh = new AdapterViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = list[position];

            // Replace the contents of the view with that element
            var holder = viewHolder as AdapterViewHolder;
            //holder.TextView.Text = items[position];
            holder.CheckBox.Text = item.videoss;
           
        }

        public override int ItemCount => list.Count;

        void OnClick(AdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(AdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);

    }

    public class AdapterViewHolder : RecyclerView.ViewHolder
    {
        //public TextView TextView { get; set; }
        public CheckBox CheckBox;


        public AdapterViewHolder(View itemView, Action<AdapterClickEventArgs> clickListener,
                            Action<AdapterClickEventArgs> longClickListener) : base(itemView)
        {
            //TextView = v;
            CheckBox = itemView.FindViewById<CheckBox>(Resource.Id.checkBox1);
            itemView.Click += (sender, e) => clickListener(new AdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new AdapterClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }

    public class AdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}