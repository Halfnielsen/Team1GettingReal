
//using system;
//using system.collections.objectmodel;
//using system.linq;
//using system.windows.input;
//using gettingreal.model;
//using gettingreal.model.repositories;
//using gettingreal.infrastructure;

//namespace gettingreal.viewmodel
//{
//    public class mainviewmodel : viewmodelbase
//    {
//        private readonly fileitemrepo _itemrepo = new("items.txt");
//        private readonly loanrepo _loanrepo = new();

//        public observablecollection<item> items { get; }
//        public observablecollection<loan> loans { get; }

//        filtrerede visninger(hentes on‑demand så de altid er friske)
//        public observablecollection<boardgame> boardgameonly =>
//            new(items.oftype<boardgame>());
//        public observablecollection<book> bookonly =>
//            new(items.oftype<book>());
//        public observablecollection<liveequipment> liveequipmentonly =>
//            new(items.oftype<liveequipment>());

//        /* ---------- selected properties ---------- */
//        private item? _selecteditem;
//        public item? selecteditem
//        {
//            get => _selecteditem;
//            set => setproperty(ref _selecteditem, value);
//        }

//        private loan? _selectedloan;
//        public loan? selectedloan
//        {
//            get => _selectedloan;
//            set => setproperty(ref _selectedloan, value);
//        }

//        /* ---------- commands ---------- */
//        public icommand additemcommand { get; }
//        public icommand edititemcommand { get; }
//        public icommand deleteitemcommand { get; }
//        public icommand createloancommand { get; }
//        public icommand completeloancommand { get; }
//        public icommand refreshcommand { get; }

//        public mainviewmodel()
//        {
//            items = new observablecollection<item>(_itemrepo.getallitems());
//            loans = new observablecollection<loan>(_loanrepo.getallloans());

//            kommando‑opsætning – ingen lambdas
//            additemcommand = new relaycommand(_ => additem());
//            edititemcommand = new relaycommand(edititemexecute, edititemcanexecute);
//            deleteitemcommand = new relaycommand(deleteitemexecute, deleteitemcanexecute);
//            createloancommand = new relaycommand(createloanexecute, createloancanexecute);
//            completeloancommand = new relaycommand(completeloanexecute, completeloancanexecute);
//            refreshcommand = new relaycommand(_ => refresh());
//        }

//        /* ---------- additem (nu parameterløs) ---------- */
//        private void additem()
//        {
//            standard‑objekt som brugeren kan redigere bagefter
//            var item = new book(
//                itemid: null,
//                name: "nyt element",
//                condition: condition.ny,
//                approvalrequirement: needsapproval.nej,
//                storagestatus: inwarehouse.hjemme,
//                system: "system",
//                edition: "udgave");

//            _itemrepo.additem(item);
//            items.add(item);
//            selecteditem = item; // sæt fokus på det nye element
//        }

//        /* ---------- edititem ---------- */
//        private void edititemexecute(object? parameter)
//        {
//            if (parameter is not item item) return;
//            _itemrepo.edititem(item);
//            refresh();
//        }
//        private bool edititemcanexecute(object? parameter) => parameter is item;

//        /* ---------- deleteitem ---------- */
//        private void deleteitemexecute(object? parameter)
//        {
//            if (parameter is not item item) return;
//            _itemrepo.deleteitem(item);
//            items.remove(item);
//        }
//        private bool deleteitemcanexecute(object? parameter) => parameter is item;

//        /* ---------- loan‑kommandoer ---------- */
//        private void createloanexecute(object? _)
//        {
//            if (selecteditem == null) return;

//            var newloanid = loans.any() ? loans.max(l => l.loanid) + 1 : 1;
//            var loan = new loan(newloanid, selecteditem.itemid, "[indtast navn]", datetime.now);
//            _loanrepo.createloan(loan);
//            loans.add(loan);

//            selecteditem.storagestatus = inwarehouse.udlånt;
//            _itemrepo.edititem(selecteditem);
//        }
//        private bool createloancanexecute(object? _) => selecteditem is { storagestatus: inwarehouse.hjemme };

//        private void completeloanexecute(object? _)
//        {
//            if (selectedloan == null) return;
//            _loanrepo.completeloan(selectedloan);
//            selectedloan.returndate = datetime.now;

//            var item = _itemrepo.getbyid(selectedloan.itemid);
//            item.storagestatus = inwarehouse.hjemme;
//            _itemrepo.edititem(item);
//            refresh();
//        }
//        private bool completeloancanexecute(object? _) => selectedloan != null && selectedloan.returndate == null;

//        /* ---------- refresh ---------- */
//        private void refresh()
//        {
//            items.clear();
//            foreach (var item in _itemrepo.getallitems())
//                items.add(item);

//            loans.clear();
//            foreach (var loan in _loanrepo.getallloans())
//                loans.add(loan);
//        }
//    }
//}
