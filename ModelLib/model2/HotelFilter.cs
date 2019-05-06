using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib.model2
{
    public class HotelFilter
    {
        private String _nameLike;
        private String _nameIs;
        private String _AddressLike;
        private String _AddressIs;

        public HotelFilter()
        {
        }

        public HotelFilter(string nameLike, string nameIs, string addressLike, string addressIs)
        {
            _nameLike = nameLike;
            _nameIs = nameIs;
            _AddressLike = addressLike;
            _AddressIs = addressIs;
        }

        public string NameLike
        {
            get => _nameLike;
            set => _nameLike = value;
        }

        public string NameIs
        {
            get => _nameIs;
            set => _nameIs = value;
        }

        public string AddressLike
        {
            get => _AddressLike;
            set => _AddressLike = value;
        }

        public string AddressIs
        {
            get => _AddressIs;
            set => _AddressIs = value;
        }

        public bool IsEmpty()
        {
            bool empty = true;

            if (String.IsNullOrWhiteSpace(NameLike)) empty = false;
            if (String.IsNullOrWhiteSpace(NameIs)) empty = false;
            if (String.IsNullOrWhiteSpace(AddressLike)) empty = false;
            if (String.IsNullOrWhiteSpace(AddressIs)) empty = false;

            return empty;
        }

        public override string ToString()
        {
            return $"{nameof(NameLike)}: {NameLike}, {nameof(NameIs)}: {NameIs}, {nameof(AddressLike)}: {AddressLike}, {nameof(AddressIs)}: {AddressIs}";
        }
    }
}
