import cianparser
import random
import psycopg2

# Подключение к базе данных
conn = psycopg2.connect(
    dbname="Real_Estate_Agency2",
    user="postgres",
    password="postgres",
    host="localhost",
    port="5432"
)
cur = conn.cursor()

type_deal = "rent_long" #sale/rent_long
spb_parser = cianparser.CianParser(location="Санкт-Петербург")

#data = spb_parser.get_flats(deal_type=type_deal, rooms=(1, 2, 3, 4), with_saving_csv=False, additional_settings={"start_page":1, "end_page":5, "is_by_homeowner": True})
#realty_type_id = 1

data = spb_parser.get_suburban(suburban_type="house",deal_type=type_deal, with_saving_csv=False, additional_settings={"start_page":1, "end_page":5, "is_by_homeowner": True})
realty_type_id = 2

print(data[0])

for flat in data:
    # Формирование адреса
    address_parts = [
        flat.get('district', ''),
        flat.get('street', ''),
        flat.get('house_number', '')
    ]
    address = ', '.join(part for part in address_parts if part)

    # Извлечение и обработка полей
    if type_deal == "sale":
        price = flat.get('price', 0)
        statuses = [1,3]   #купить квартиру
    else:
        price = flat.get('price_per_month')
        statuses = [2,3]   #сдать квартиру
    area = flat.get('total_meters', 0.0)
    rooms = flat.get('rooms_count', 0)
    floor = None if flat.get('floor', -1) == -1 else flat.get('floor')
    underground = flat.get('underground', '')
    residential_complex = flat.get('residential_complex', '')
    url = flat.get('url', '')

    # Генерация случайных значений
    owner_id = random.randint(1, 50)
    if realty_type_id == 1:
        image = f"realty{random.randint(13, 50)}.jpg"
    else:
        image = f"house{random.randint(1, 50)}.jpg"

    # Случайный выбор realty_status_id с весами (1:5 для 1 и 1:5 для 3)
    weights = [3, 1]
    realty_status_id = random.choices(statuses, weights=weights, k=1)[0]

    # Выполнение INSERT-запроса
    cur.execute("""
        INSERT INTO realty (
            realty_address, realty_price, realty_type_id, realty_area, realty_rooms,
            realty_status_id, owner_id, image, url, floor, underground, residential_complex
        )
        VALUES (%s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s)
    """, (
        address, price, realty_type_id, area, rooms, realty_status_id, owner_id, image, url, floor, underground, residential_complex
    ))

# Подтверждение транзакции и закрытие соединения
conn.commit()
cur.close()
conn.close()