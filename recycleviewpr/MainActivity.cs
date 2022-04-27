using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;

namespace recycleviewpr
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
       
        private List<datamodal> list;
        private RecyclerView recyclerView;
        private RecyclerView.LayoutManager layoutManager;
        private Adapter adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView1);
            addingdata();
            layoutManager = new LinearLayoutManager(this, LinearLayoutManager.Vertical, true);
            recyclerView.SetLayoutManager(layoutManager);
            adapter = new Adapter(list, this);
            recyclerView.SetAdapter(adapter);

        }

        private void addingdata()
        {
            list = new List<datamodal>
            {    new datamodal{videoss="Dengue Fever"}, new datamodal{videoss="Malaria"},
            new datamodal{videoss="Pneumonia "},new datamodal{videoss="Diarrhea "},
             new datamodal{videoss="High Blood Pressure/ Hypertension "},new datamodal{videoss="Common Cold & Fever "},
              new datamodal{videoss="Jaundice  "},new datamodal{videoss="Tuberculosis  "},
               new datamodal{videoss="Depression   "},
            };
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}