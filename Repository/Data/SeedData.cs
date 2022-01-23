using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Repository.Data
{
    public static class SeedData
    {
        public static void Initialize(Context context)
        {
            if (!context.Genders.Any())
            {
                context.Genders.AddRange(Genders);
                context.SaveChanges();
            }
            if (!context.Laws.Any())
            {
                context.Laws.AddRange(Laws);
                context.SaveChanges();
            }
            if (!context.Cities.Any())
            {
                context.Cities.AddRange(Cities);
                context.SaveChanges();
            }
            if (!context.Services.Any())
            {
                context.Services.AddRange(Services);
                context.SaveChanges();
            }
            if (!context.Clients.Any())
            {
                context.Clients.AddRange(Clients);
                context.SaveChanges();
            }
            if (!context.Contracts.Any())
            {
                context.Contracts.AddRange(Contracts);
                context.SaveChanges();
            }
            if (!context.PaymentDoсs.Any())
            {
                context.PaymentDoсs.AddRange(PaymentDocs);
                context.SaveChanges();
            }
        }
        private static readonly IEnumerable<Gender> Genders = new List<Gender>()
        {
            new Gender()
            {
                Name = "Мужской",
            },
            new Gender()
            {
                Name = "Женский",
            },
            new Gender()
            {
                Name = "Другой :)",
            },
        };
        private static readonly IEnumerable<Law> Laws = new List<Law>()
        {
            new Law()
            {
                ArticleNumber = 153,
                Wording = "Обязанность по внесению платы за жилое помещение и коммунальные услуги",
            },
            new Law()
            {
                ArticleNumber = 157,
                Wording = "Размер платы за коммунальные услуги",
            },
            new Law()
            {
                ArticleNumber = 158,
                Wording = "Размер платы за жилое помещение",
            },
            new Law()
            {
                ArticleNumber = 160,
                Wording = "Компенсации расходов на оплату жилых помещений и коммунальных услуг",
            },
        };
        private static readonly IEnumerable<City> Cities = new List<City>()
        {
            new City()
            {
                Name = "Москва",
            },
            new City()
            {
                Name = "Воронеж",
            },
            new City()
            {
                Name = "Владивосток",
            },
            new City()
            {
                Name = "Челябинск",
            },
            new City()
            {
                Name = "Смоленск",
            },
            new City()
            {
                Name = "Курск",
            },
            new City()
            {
                Name = "Липецк",
            },
            new City()
            {
                Name = "Чита",
            },
            new City()
            {
                Name = "Казань",
            },
        };
        private static readonly IEnumerable<Service> Services = new List<Service>()
        {
            new Service()
            {
                Name = "Теплоснабжение",
                Destination = "Функциональное",
            },
            new Service()
            {
                Name = "Евроремонт",
                Destination = "Эстетическое",
            },
            new Service()
            {
                Name = "Электроснабжение",
                Destination = "Функциональное",
            },
            new Service()
            {
               Name = "Освещение улиц",
               Destination = "Эстетическое",
            },
        };
        private static readonly IEnumerable<Client> Clients = new List<Client>()
        {
            new Client()
            {
                FIO = "Малышев Владислав Маркович",
                PassportSeriesAndNumber = "2018 513234",
                DateBirth = "11.12.1998",
                Address = "Ленинский проспект, 17, 56",
                City = Cities.ElementAt(0),
                Gender = Genders.ElementAt(0),
            },
            new Client()
            {
                FIO = "Леонова Татьяна Андреевна",
                PassportSeriesAndNumber = "2010 123634",
                DateBirth = "01.05.1988",
                Address = "ул. Солнечная, 7, 12",
                City = Cities.ElementAt(1),
                Gender = Genders.ElementAt(1),
            },
            new Client()
            {
                FIO = "Головин Элина Артёмович",
                PassportSeriesAndNumber = "2020 232539",
                DateBirth = "10.01.2000",
                Address = "ул. Гончарная, 9, 22",
                City = Cities.ElementAt(2),
                Gender = Genders.ElementAt(2),
            },
            new Client()
            {
                FIO = "Добрыня Никитич",
                PassportSeriesAndNumber = "1070 827327",
                DateBirth = "14.05.1050",
                Address = "ул. Старословянская, 3 изба",
                City = Cities.ElementAt(6),
                Gender = Genders.ElementAt(0),
            },
        };
        private static readonly IEnumerable<Contract> Contracts = new List<Contract>()
        {
            new Contract()
            {
                ContractNumber = "23764218",
                PayableAmount = 4663,
                PaymentTerm = new DateTime(2022, 11, 03, 00,00,00),
                Service = Services.ElementAt(2),
                Client = Clients.ElementAt(1),
                Law = Laws.ElementAt(1),
            },
            new Contract()
            {
                ContractNumber = "45983421",
                PayableAmount = 5110,
                PaymentTerm = new DateTime(2023, 06, 08, 00,00,00),
                Service = Services.ElementAt(3),
                Client = Clients.ElementAt(0),
                Law = Laws.ElementAt(2),
            },
            new Contract()
            {
                ContractNumber = "8423764",
                PayableAmount = 12000,
                PaymentTerm = new DateTime(2024, 01, 07, 00,00,00),
                Service = Services.ElementAt(0),
                Client = Clients.ElementAt(2),
                Law = Laws.ElementAt(3),
            },
            new Contract()
            {
                ContractNumber = "5846374",
                PayableAmount = 100,
                PaymentTerm = new DateTime(1950, 02, 12, 00,00,00),
                Service = Services.ElementAt(3),
                Client = Clients.ElementAt(3),
                Law = Laws.ElementAt(0),
            },
        };
        private static readonly IEnumerable<PaymentDoс> PaymentDocs = new List<PaymentDoс>()
        {
            new PaymentDoс()
            {
                Name = "Квитанция",
                Contract = Contracts.ElementAt(0),
                Client = Clients.ElementAt(0),
            },
            new PaymentDoс()
            {
                Name = "Чек",
                Contract = Contracts.ElementAt(1),
                Client = Clients.ElementAt(2),
            },
            new PaymentDoс()
            {
                Name = "Квитанция",
                Contract = Contracts.ElementAt(1),
                Client = Clients.ElementAt(1),
            },
            new PaymentDoс()
            {
                Name = "Талон",
                Contract = Contracts.ElementAt(2),
                Client = Clients.ElementAt(0),
            },
            new PaymentDoс()
            {
                Name = "Письмо",
                Contract = Contracts.ElementAt(3),
                Client = Clients.ElementAt(3),
            },
        };
    }
}
