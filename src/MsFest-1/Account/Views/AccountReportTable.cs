using System;
using System.Collections;
using System.Collections.Generic;

namespace MsFest_1.Account.Views
{
    public class AccountReportTable : IEnumerable<AccountRow>
    {
        readonly Dictionary<Guid, AccountRow> _rows;

        public AccountReportTable()
        {
            _rows = new Dictionary<Guid, AccountRow>();
        }

        public void OpenAccount(Guid id)
        {
            _rows.Add(id, new AccountRow());
        }

        public void SetUser(Guid id, string name, string address)
        {
            _rows[id] = new AccountRow {Id = id, Name = name, Address = address};
        }


        public IEnumerator<AccountRow> GetEnumerator()
        {
            return _rows.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void ChangeAddress(Guid id, string address)
        {
            _rows[id].Address = address;
        }
    }
}