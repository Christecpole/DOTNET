using CorrectionEFcore.Data;
using CorrectionEFcore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionEFcore.Repository
{
    internal class ContactRepository
    {
        public Contact Add (Contact contact)
        {
            using(var db = new ContactDbContext())
            {
                try
                {
                    db.contacts.Add(contact);
                    db.SaveChanges();
                    return contact;

                }catch(Exception ex)
                {
                    return null;
                }
               
            }
        }

        public List<Contact> Get()
        {
            using(var db = new ContactDbContext())
            {
                try
                {
                    return db.contacts.ToList();
                }catch(Exception ex)
                {
                    return new List<Contact>();
                }
            }
        }

        public Contact Get(int id)
        {
            using(var db = new ContactDbContext())
            {
                try
                {
                    return db.contacts.Find(id);
                }catch(Exception ex)
                {
                    return null;
                }
                

            }
        }

        public bool Update (int id,Contact contact)
        {
            using(var db = new ContactDbContext())
            {
                try
                {
                    Contact contactFound = db.contacts.Find(id);
                    if (contactFound == null) return false;
                    foreach (var prop in typeof(Contact).GetProperties())
                    {
                        if (prop.Name != "Id" && prop.GetValue(contact) != null)
                        {
                            prop.SetValue(contactFound, prop.GetValue(contact));
                        }
                    }

                    //if(contact.Nom != null)
                    //{
                    //    contactFound.Nom = contact.Nom;
                    //}
                    //if(contact.Prenom != null)
                    //{
                    //    contactFound.Prenom = contact.Prenom;
                    //}

                    db.SaveChanges();
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
              
            }
        }

        public bool Delete (int id)
        {
            using(var db = new ContactDbContext())
            {
                try
                {
                    Contact contactFound = Get(id);
                    if (contactFound == null) return false;

                    db.contacts.Remove(contactFound);
                    db.SaveChanges();
                    return true;
                }catch(Exception ex)
                {
                    return false;
                }

            }
        }

    }
}
