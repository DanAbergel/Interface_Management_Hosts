using BE;
using DS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DAL
{
    class DAL_Xml_imp:IDAL
    {
        XElement HostingRoot;
        string hostingPath = @"hostingXml.xml";

        XElement configRoot;
        string configPath = @"config.xml";

        string orderPath = @"orderXml.xml";
        string guestPath = @"guestXml.xml";

        
        bool HostingListChanged = true;


        #region constructeur

        /// <summary>
        /// DAL_XML_imp ctor
        /// </summary>
        internal DAL_Xml_imp()
        {
            if (!File.Exists(configPath))
            {
                SaveConfigToXml();
            }
            else
            {
                configRoot = XElement.Load(configPath);
            }
            if (!File.Exists(hostingPath))
            {
                HostingRoot = new XElement("Hosting");
                HostingRoot.Save(hostingPath);
            }
            if (!File.Exists(guestPath))
            {
                SaveToXML(new List<GuestRequest>(), guestPath);
            }
            if (!File.Exists(orderPath))
            {
                SaveToXML(new List<Order>(), orderPath);
            }
            HostingRoot = XElement.Load(hostingPath);

            DataSource.guestRequests = LoadFromXML<List<GuestRequest>>(guestPath);
            //DataSource.orders = LoadFromXML<List<Order>>(orderPath);
        }
        #endregion

        #region detor
        /// <summary>
        /// dtor
        /// </summary>
        ~DAL_Xml_imp()
        {
            HostingRoot.Save(hostingPath);
            SaveToXML<List<GuestRequest>>(DataSource.guestRequests, guestPath);
            SaveToXML<List<Order>>(DataSource.orders, orderPath);
            SaveConfigToXml();
        }
        #endregion



        /// <summary>
        /// Save Configuration To Xml
        /// </summary>
        private void SaveConfigToXml()
        {
            configRoot = new XElement("config");
            try
            {
                configRoot.Add(new XElement("comissionPerDay", BE.Configuration.comissionPerDay));
                /* r ajouter toutes les config necessaire
                 * 
                 * 
                 * 
                 * */
                configRoot.Save(configPath);
            }
            catch (Exception)
            { }
        }


        #region guest request

        /// <summary>
        /// Get guest request
        /// </summary>
        /// <param name="guestRequestKey"></param>
        /// <returns></returns>
        public BE.GuestRequest GetGuestRequestByID(long guestRequestKey)
        {
            return DataSource.guestRequests.FirstOrDefault(t => t.guestRequestKey== guestRequestKey);
        }

        /// <summary>
        /// Add guestrequest
        /// </summary>
        /// <param name="guestRequest"></param>
        public void addGuestRequest(BE.GuestRequest guestRequest)
        {
            if (!GuestRequestExist(guestRequest.guestRequestKey))
            {
                DataSource.guestRequests.Add(guestRequest.Clone());
            }

            else
                throw new KeyNotFoundException("la requete existe deja");

            SaveToXML<List<GuestRequest>>(DataSource.guestRequests, guestPath);
        }

        /// <summary>
        /// Get All guests request
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<BE.GuestRequest> getAllGuestRequest(Func<BE.GuestRequest, bool> predicate = null)
        {
            if (predicate == null)
                return DataSource.guestRequests.AsEnumerable().Select(t => t.Clone());
            return DataSource.guestRequests.Where(predicate).Select(t => t.Clone());
        }

        /// <summary>
        /// Remove guest request
        /// </summary>
        /// <param name="ID"></param>
        public void deleteGuestRequest(long guestRequestKey)
        {
            BE.GuestRequest guestRequest = GetGuestRequestByID(guestRequestKey);
            DataSource.guestRequests.Remove(guestRequest);
            SaveToXML<List<GuestRequest>>(DataSource.guestRequests, guestPath);
        }


        /// <summary>
        /// Update guest request
        /// </summary>
        /// <param name="updateGuestRequest"></param>
        public void updateGuestRequest(BE.GuestRequest updateGuestRequest)
        {
            if (GuestRequestExist(updateGuestRequest.guestRequestKey))
            {
                var result = (from GuestRequest in DataSource.guestRequests
                              where GuestRequest.guestRequestKey == updateGuestRequest.guestRequestKey
                              select GuestRequest).First();
                DataSource.guestRequests.Remove(result);
                DataSource.guestRequests.Add(updateGuestRequest.Clone());
            }
            else
                throw new KeyNotFoundException("la requete n existe pas");
            SaveToXML<List<GuestRequest>>(DataSource.guestRequests, guestPath);
        }
       
        /// <summary>
        /// check request exist
        /// </summary>
        /// <param name="guestRequestKey"></param>
        /// <returns></returns>
        public bool GuestRequestExist(long guestRequestKey)
        {
            GuestRequest tmp = (from GuestRequest in DataSource.guestRequests
                                where GuestRequest.guestRequestKey == guestRequestKey
                                select GuestRequest).FirstOrDefault();
            if (tmp == default(GuestRequest))
                return false;
            else
                return true;

        }


        #endregion

                
        #region hosting unit

        /// <summary>
        /// Get hosting from xml
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public BE.HostingUnit GetHostingUnitByID(string ID)
        {
            return (from trainee in HostingRoot.Elements().Where(t => t.Element("ID").Value == ID)
                    select
                 new HostingUnit()).FirstOrDefault();
        }

        /// <summary>
        /// Add hosting to xml
        /// </summary>
        /// <param name="hostingUnit"></param>
        public void addHostingUnit(BE.HostingUnit hostingUnit)
        {
            if (!HostingUnitExist(hostingUnit.HostingUnitKey))
            {
                XElement t = new XElement("hosting");
                t.Add(//new XElement("ID", hostingUnit.Owner.ID),
                      //new XElement("HostingUnitKey", hostingUnit.HostingUnitKey),
                      new XElement("capacityChildren", hostingUnit.capacityChildren),
                      //new XElement("capacityChildren", hostingUnit.capacityChildren),
                      //new XElement("capacityChildren", hostingUnit.capacityChildren),
                      new XElement("capacityAdults", hostingUnit.capacityAdults),
                      new XElement("FamilyName", hostingUnit.Owner.FamilyName),
                      new XElement("PrivateName", hostingUnit.Owner.PrivateName),
                      new XElement("CollectionClearance", hostingUnit.Owner.CollectionClearance.ToString()),
                      new XElement("PhoneNumber", hostingUnit.Owner.PhoneNumber),
                      new XElement("MailAddress", hostingUnit.Owner.MailAddress.ToString()),
                      new XElement("Address", hostingUnit.address.ToString()),
                      new XElement("pricePerDayPerAdult", hostingUnit.pricePerDayPerAdult.ToString()),
                      new XElement("pricePerDayPerChild", hostingUnit.pricePerDayPerChild.ToString()),
                      new XElement("HostingUnitName", hostingUnit.HostingUnitName),
                      //new XElement("numOfHostingUnit", hostingUnit.Owner.numOfHostingUnit),
                      //new XElement("occupied", hostingUnit.occupied.ToString()),
                      //new XElement("Diary", hostingUnit.Diary.ToString()),
                      //new XElement("succesfulDeals", hostingUnit.succesfulDeals.ToString()),
                      new XElement("pool", hostingUnit.pool.ToString()),
                      new XElement("garden", hostingUnit.garden.ToString()),
                      new XElement("jacuzzi", hostingUnit.jacuzzi.ToString()),
                      new XElement("childrenAttraction", hostingUnit.childrenAttraction.ToString()),
                      new XElement("area", hostingUnit.area.ToString()));
                      //new XElement("BankNumber", hostingUnit.Owner.Account.BankNumber.ToString()),
                      //new XElement("BankName", hostingUnit.Owner.Account.BankName.ToString()),
                      //new XElement("BranchNumber", hostingUnit.Owner.Account.BranchNumber.ToString()),
                      //new XElement("BranchAddress", hostingUnit.Owner.Account.BranchAddress.ToString()),
                      //new XElement("BranchCity", hostingUnit.Owner.Account.BranchCity.ToString()));
                HostingRoot.Add(t);
                HostingRoot.Save(hostingPath);
                HostingListChanged = true;
                
                hostingUnit.Owner.numOfHostingUnit++;
            }
            else
                throw new KeyNotFoundException("le logement existe deja");
            
        }


        /// <summary>
        /// Get All hosting from xml.
        /// </summary>
        /// <param name="predicate"> Optional - Using predicate.</param>
        /// <returns></returns>
        public IEnumerable<BE.HostingUnit> getAllHostingUnits(Func<BE.HostingUnit, bool> predicate = null)
        {
            try
            {
                if (HostingListChanged)
                {
                    DataSource.hostingUnits = (from hosting in HostingRoot.Elements() select new HostingUnit()).ToList();
                    HostingListChanged = false;
                }
            }
            catch (Exception)
            {
                throw new Exception("בעיה בקובץ היחידות");
            }
            if (predicate == null)
                return DataSource.hostingUnits.AsEnumerable().Select(t => t.Clone());
            return DataSource.hostingUnits.Where(predicate).Select(t => t.Clone());
        }

        /// <summary>
        /// Remove hosting from xml
        /// </summary>
        /// <param name="HostingUnitKey"></param>
        public void deleteHostingUnit(string HostingUnitKey)
        {
            XElement HostingElement = (from t in HostingRoot.Elements()
                                       where t.Element("HostingUnitKey").Value == HostingUnitKey
                                       select t).FirstOrDefault();
            if (HostingElement == null)
                throw new KeyNotFoundException("לא נמצא יחידה שמספרו " + HostingUnitKey);
            try
            {
                HostingElement.Remove();
                HostingListChanged = true;
                HostingRoot.Save(hostingPath);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Update hosting to xml
        /// </summary>
        /// <param name="updateHostingUnit"></param>
        public void uptadeHostingUnit(BE.HostingUnit updateHostingUnit)
        {
            try
            {
                XElement t = (from item in HostingRoot.Elements()
                              where item.Element("ID").Value == updateHostingUnit.HostingUnitKey
                              select item).FirstOrDefault();
                         t.Element("ID").Value= updateHostingUnit.Owner.ID;
                         t.Element("capacityAdults").Value= updateHostingUnit.capacityAdults.ToString();
                         t.Element("FamilyName").Value= updateHostingUnit.Owner.FamilyName;
                         t.Element("PrivateName").Value= updateHostingUnit.Owner.PrivateName.ToString();
                         t.Element("CollectionClearance").Value = updateHostingUnit.Owner.CollectionClearance.ToString();
                         t.Element("PhoneNumber").Value= updateHostingUnit.Owner.PhoneNumber;
                         t.Element("MailAddress").Value = updateHostingUnit.Owner.MailAddress.ToString();
                         t.Element("Address").Value = updateHostingUnit.address;
                         t.Element("pricePerDayPerAdult").Value = updateHostingUnit.pricePerDayPerAdult.ToString();
                         t.Element("pricePerDayPerChild").Value = updateHostingUnit.pricePerDayPerChild.ToString();
                         t.Element("HostingUnitName").Value = updateHostingUnit.HostingUnitName;
                         t.Element("numOfHostingUnit").Value = updateHostingUnit.Owner.numOfHostingUnit.ToString();
                         t.Element("occupied").Value = updateHostingUnit.occupied.ToString();
                         t.Element("Diary").Value = updateHostingUnit.Diary.ToString();
                         t.Element("succesfulDeals").Value = updateHostingUnit.succesfulDeals.ToString();
                         t.Element("pool").Value = updateHostingUnit.pool.ToString();
                         t.Element("garden").Value = updateHostingUnit.garden.ToString();
                         t.Element("jacuzzi").Value = updateHostingUnit.jacuzzi.ToString();
                         t.Element("childrenAttraction").Value = updateHostingUnit.childrenAttraction.ToString();
                         t.Element("area").Value = updateHostingUnit.area.ToString();
                         t.Element("BankNumber").Value = updateHostingUnit.Owner.Account.BankNumber.ToString();
                         t.Element("BankName").Value = updateHostingUnit.Owner.Account.BankName.ToString();
                         t.Element("BranchNumber").Value = updateHostingUnit.Owner.Account.BranchNumber.ToString();
                         t.Element("BranchAddress").Value = updateHostingUnit.Owner.Account.BranchAddress.ToString();
                         t.Element("BranchCity").Value = updateHostingUnit.Owner.Account.BranchCity.ToString();

                HostingRoot.Save(hostingPath);
                HostingListChanged = true;
            }
            catch (Exception)
            {
                throw new KeyNotFoundException("שגיאה בעדכון היחידה " + updateHostingUnit.Owner.ID);
            }
        }

        /// <summary>
        /// check hosting exist
        /// </summary>
        /// <param name="HostingUnitKey"></param>
        /// <returns></returns>
        public bool HostingUnitExist(string HostingUnitKey)
        {
            HostingUnit tmp = (from HostingUnit in DataSource.hostingUnits
                               where HostingUnit.HostingUnitKey == HostingUnitKey
                               select HostingUnit).FirstOrDefault();
            if (tmp == default(HostingUnit))
                return false;
            else
                return true;
        }



        #endregion

        #region order

        /// <summary>
        /// Get order
        /// </summary>
        /// <param name="OrderKey"></param>
        /// <returns></returns>
        public BE.Order GetOrderByID(string OrderKey)
        {
            return DataSource.orders.FirstOrDefault(t => t.OrderKey == OrderKey);
        }


        /// <summary>
        /// Add order
        /// </summary>
        /// <param name="order"></param>
        public void addOrder(BE.Order order)
        {
            DataSource.orders.Add(order.Clone());
            SaveToXML<List<Order>>(DataSource.orders, orderPath);
        }



        /// <summary>
        /// Get All orders
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<BE.Order> getAllOrders(Func<BE.Order, bool> predicate = null)
        {
            if (predicate == null)
                return DataSource.orders.AsEnumerable().Select(t => t.Clone());
            return DataSource.orders.Where(predicate).Select(t => t.Clone());
        }

        /// <summary>
        /// Update order 
        ///  </summary>
        /// <param name="order"></param>
        public void updateOrder(BE.Order updateOrder)
        {
            if (OrderExist(updateOrder.OrderKey))
            {
                var result = (from Order in DataSource.orders
                              where Order.OrderKey == updateOrder.OrderKey
                              select Order).First();
                DataSource.orders.Remove(result);
                DataSource.orders.Add(updateOrder.Clone());
            }
            else
                throw new KeyNotFoundException("aucune commande n'a été trouve");
            SaveToXML<List<Order>>(DataSource.orders, orderPath);
        }

        /// <summary>
        /// Remove order
        /// </summary>
        /// <param name="orderKey"></param>
        public void deleteOrder(string orderKey)
        {
            BE.Order order = GetOrderByID(orderKey);
            DataSource.orders.Remove(order);
            SaveToXML<List<Order>>(DataSource.orders, orderPath);
        }


        /// <summary>
        /// check order exist
        /// </summary>
        /// <param name="OrderKey"></param>
        /// <returns></returns>
        public bool OrderExist(string OrderKey)
        {
            Order tmp = (from Order in DataSource.orders
                         where Order.OrderKey == OrderKey
                         select Order).FirstOrDefault();
            if (tmp == default(Order))
                return false;
            else
                return true;

        }


        #endregion

        #region load and save

        /// <summary>
        /// Save To XML tamplate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="path"></param>
        public static void SaveToXML<T>(T source, string path)
        {
            FileStream file = new FileStream(path, FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(source.GetType());
            xmlSerializer.Serialize(file, source); file.Close();
        }

        /// <summary>
        /// Load From XML tamplate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T LoadFromXML<T>(string path)
        {
            FileStream file = new FileStream(path, FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            T result = (T)xmlSerializer.Deserialize(file);
            file.Close();
            return result;
        }

        #endregion


        /// <summary>
        /// Get All bank account
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<BE.BankBranch> GetAllBankAccounts(Func<BE.BankBranch, bool> predicate = null)
        {
            if (predicate == null)
                return DataSource.allBankAccounts.AsEnumerable().Select(t => t.Clone());
            return DataSource.allBankAccounts.Where(predicate).Select(t => t.Clone());
        }

        /// <summary>
        /// Get All host
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<BE.Host> getAllHost(Func<BE.Host, bool> predicate = null)
        {
            if (predicate == null)
                return DataSource.hosts.AsEnumerable().Select(t => t.Clone());
            return DataSource.hosts.Where(predicate).Select(t => t.Clone());
        }

        public List<HostingUnit> getHostingUnits(Func<HostingUnit, bool> predicate = null)
        {
            return DataSource.hostingUnits.Where(predicate).Select(hu => (HostingUnit)hu.Clone()).ToList();
        }
    }
}
