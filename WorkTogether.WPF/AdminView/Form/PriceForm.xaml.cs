using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WorkTogether.Data;
using WorkTogether.Data.Models;
using WorkTogether.Data.Repository;
using WorkTogether.WPF._core;
using static System.Net.Mime.MediaTypeNames;

namespace WorkTogether.WPF.AdminView.Form
{
    /// <summary>
    /// Logique d'interaction pour PriceForm.xaml
    /// </summary>
    public partial class PriceForm : UserControl, IForm<Price>
    {
        private PageList _page;
        private PriceRepository _repository;
        private Price? _SelectedData = null;
        private BtnForm _btn;
        private Price _latestPrice;
        PageList IForm.Page => _page;
        EntityRepository<Price> IForm<Price>.Repository => _repository;

        public Price? SelectedData
        {
            get => _SelectedData;
            set
            {
                _SelectedData = value;
                Reload();
            }
        }

        public PriceForm(PageList page)
        {
            InitializeComponent();
            _page = page;
            _repository = new PriceRepository(_page.Window.Context);
            _btn = new BtnForm(this);
            Btn.Content = _btn;
            Clear();
        }

        public void Save()
        {
            int value = System.Convert.ToInt32(TxtPrice.Text.Trim());
            DateTime? start = SelectedDate.SelectedDate;

            if (start == null)
                throw new Exception("La date de mise en place ne peut être null !");

            if (start <= DateTime.Now)
                throw new Exception("La date de mise en place doit être une date future !");
            if (_SelectedData == null)
            {
                if (start <= _latestPrice.Start)
                    throw new Exception("La date de mise en place doit être postérieur à la date de début du prix précédent !");
            }
            else
            {
                if (start <= _SelectedData.Preceding.Start)
                    throw new Exception("La date de mise en place doit être postérieur à la date de début du prix précédent !");
                if (_SelectedData.Successor != null && start >= _SelectedData.Successor.Start)
                    throw new Exception("La date de mise en place doit être antérieur à la date de début du prix suivant !");
            }



            if (_SelectedData == null)
                {
                    _SelectedData = new Price();
                    _SelectedData.Preceding = _latestPrice;
                }

            _SelectedData.Value = value;
            _SelectedData.Start = (DateTime)start;

            _SelectedData.Preceding.End = ((DateTime)start).AddDays(-1);

            _repository.Save(_SelectedData);
            Clear();
        }

        void IForm.Delete()
        {
            if (SelectedData == null)
                return;

            if (!SelectedData.IsDeleteable())
                throw new Exception("This Price isn't deletable!");

            var current = SelectedData;
            var prev = current.Preceding;
            var next = current.Successor;

            current.Preceding = null;
            current.Successor = null;
            current.PrecedingId = null;


            // CAS 1 : dernier élément
            if (next == null)
            {
                if (prev != null)
                    prev.End = null;
            }
            else
            {
                // CAS 2 : élément au milieu

                if (prev != null)
                {
                    prev.Successor = next;
                    next.Start = ((DateTime)prev.End).AddDays(1);
                }

                next.Preceding = prev;
                next.PrecedingId = prev?.Id;
                _repository.Save(next);
            }

            _repository.Save(prev);
            _repository.Delete(current);
            Clear();
        }

        public void Reload()
        {
            if (_SelectedData == null)
                return;
            TxtPrice.Text = _SelectedData.Value.ToString();
            SelectedDate.SelectedDate = _SelectedData.Start;
            _btn.SetEdit();
        }

        public void Clear()
        {
            _latestPrice = _repository.FindLatest();
            TxtPrice.Text = _latestPrice.Value.ToString();
            if (DateTime.Now.AddDays(1) > _latestPrice.Start.AddDays(1))
                SelectedDate.SelectedDate = DateTime.Now.AddDays(1);
            else
                SelectedDate.SelectedDate = _latestPrice.Start.AddDays(1);
            _SelectedData = null;
            _btn.SetNew();
            ((IForm<Price>)this).LoadList();
        }
    }
}
