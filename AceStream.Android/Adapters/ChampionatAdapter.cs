using System.Collections.Generic;
using AceStream.Dto;
using Android.App;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace AceStream.Android.Adapters
{
    [Activity(Label = "ChampionatAdapter")]
    public class ChampionatAdapter : BaseAdapter<ChampionatDto>
    {
        List<ChampionatDto> _championats;
        Activity _context;

        public ChampionatAdapter(Activity context, List<ChampionatDto> championats) : base()
        {
            _context = context;
            _championats = championats;
        }
        public override long GetItemId(int position)
        {
            return position;
        }

        public override int Count
        {
            get { return _championats.Count; }
        }

        public override ChampionatDto this[int position]
        {
            get { return _championats[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var championat = _championats[position];

            var view = convertView;

            if (view == null)
            {
                view = _context.LayoutInflater.Inflate(Resource.Layout.championat_list_item, null);
            }
            view.FindViewById<TextView>(Resource.Id.name).Text = championat.Name;
            view.FindViewById<TextView>(Resource.Id.country).Text = championat.Country;

            //var resourceId = (int)typeof(Resource.Drawable).GetField(championat.Image).GetValue(null);

            //view.FindViewById<ImageView>(Resource.Id.icon).SetImageResource(resourceId);

            return view;
        }

        
    }
}
