PGDMP  !    :                }            Real_Estate_Agency2    17.4    17.4 �    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                           false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                           false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                           false            �           1262    16744    Real_Estate_Agency2    DATABASE     {   CREATE DATABASE "Real_Estate_Agency2" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'ru-RU';
 %   DROP DATABASE "Real_Estate_Agency2";
                     postgres    false                       1255    16796 �   add_agent(integer, text, text, text, text, text, integer, text, timestamp without time zone, timestamp without time zone, integer, double precision, text) 	   PROCEDURE     �  CREATE PROCEDURE public.add_agent(IN p_agent_id integer, IN p_agent_login text, IN p_agent_password text, IN p_firstname text, IN p_lastname text, IN p_phone text, IN p_experience integer, IN p_email text, IN p_birthday timestamp without time zone, IN p_hire_date timestamp without time zone, IN p_percent integer, IN p_amount double precision, IN p_image text)
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO agents (
		agent_id,
		agent_login,
		agent_password,
        agent_firstname, 
        agent_lastname, 
        agent_phone, 
        agent_experience, 
        agent_email, 
        agent_birthday, 
        agent_hire_date, 
        agent_percent, 
        agent_amount, 
        image
    ) VALUES (
		p_agent_id,
		p_agent_login,
		p_agent_password,
        p_firstname, 
        p_lastname, 
        p_phone, 
        p_experience, 
        p_email, 
        p_birthday, 
        p_hire_date, 
        p_percent, 
        p_amount, 
        p_image
    );
END $$;
 i  DROP PROCEDURE public.add_agent(IN p_agent_id integer, IN p_agent_login text, IN p_agent_password text, IN p_firstname text, IN p_lastname text, IN p_phone text, IN p_experience integer, IN p_email text, IN p_birthday timestamp without time zone, IN p_hire_date timestamp without time zone, IN p_percent integer, IN p_amount double precision, IN p_image text);
       public               postgres    false            �            1255    16754 ]   add_client(integer, character varying, character varying, character, character varying, text) 	   PROCEDURE     5  CREATE PROCEDURE public.add_client(IN p_client_id integer, IN p_client_firstname character varying, IN p_client_lastname character varying, IN p_client_phone character, IN p_client_email character varying, IN p_image text)
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO clients (
      client_id,
      client_firstname,
      client_lastname, 
      client_phone,
      client_email,
      image
    ) VALUES (
      p_client_id,
      p_client_firstname, 
      p_client_lastname, 
      p_client_phone, 
      p_client_email, 
      p_image
    );
END $$;
 �   DROP PROCEDURE public.add_client(IN p_client_id integer, IN p_client_firstname character varying, IN p_client_lastname character varying, IN p_client_phone character, IN p_client_email character varying, IN p_image text);
       public               postgres    false            +           1255    25753 $   add_client_request(integer, integer) 	   PROCEDURE     �   CREATE PROCEDURE public.add_client_request(IN p_client_id integer, IN p_realty_id integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO client_requests (client_id, realty_id)
    VALUES (p_client_id, p_realty_id);
END;
$$;
 Z   DROP PROCEDURE public.add_client_request(IN p_client_id integer, IN p_realty_id integer);
       public               postgres    false            '           1255    25748 *   add_client_request(integer, integer, date) 	   PROCEDURE     2  CREATE PROCEDURE public.add_client_request(IN p_client_id integer, IN p_realty_id integer, IN p_request_date date DEFAULT CURRENT_DATE)
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO client_requests (client_id, realty_id, request_date)
    VALUES (p_client_id, p_realty_id, p_request_date);
END;
$$;
 r   DROP PROCEDURE public.add_client_request(IN p_client_id integer, IN p_realty_id integer, IN p_request_date date);
       public               postgres    false                       1255    25754 -   add_client_request(integer, integer, integer) 	   PROCEDURE     -  CREATE PROCEDURE public.add_client_request(IN p_client_request_id integer, IN p_client_id integer, IN p_realty_id integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO client_requests (client_request_id,client_id, realty_id)
    VALUES (p_client_request_id,p_client_id, p_realty_id);
END;
$$;
 z   DROP PROCEDURE public.add_client_request(IN p_client_request_id integer, IN p_client_id integer, IN p_realty_id integer);
       public               postgres    false                       1255    25650 [   add_deal(integer, integer, integer, integer, timestamp without time zone, double precision) 	   PROCEDURE     �  CREATE PROCEDURE public.add_deal(IN p_deal_id integer, IN p_realty_id integer, IN p_client_id integer, IN p_agent_id integer, IN p_deal_date timestamp without time zone, IN p_deal_cost double precision)
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO deals (deal_id, realty_id, client_id, agent_id, deal_date, deal_cost)
    VALUES (p_deal_id,p_realty_id, p_client_id, p_agent_id, p_deal_date, p_deal_cost);
END $$;
 �   DROP PROCEDURE public.add_deal(IN p_deal_id integer, IN p_realty_id integer, IN p_client_id integer, IN p_agent_id integer, IN p_deal_date timestamp without time zone, IN p_deal_cost double precision);
       public               postgres    false            �            1255    16770 \   add_owner(integer, character varying, character varying, character, character varying, text) 	   PROCEDURE     $  CREATE PROCEDURE public.add_owner(IN p_owner_id integer, IN p_owner_firstname character varying, IN p_owner_lastname character varying, IN p_owner_phone character, IN p_owner_email character varying, IN p_image text)
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO owners (
      owner_id,
      owner_firstname,
      owner_lastname, 
      owner_phone,
      owner_email,
      image
    ) VALUES (
      p_owner_id,
      p_owner_firstname, 
      p_owner_lastname, 
      p_owner_phone, 
      p_owner_email, 
      p_image
    );
END $$;
 �   DROP PROCEDURE public.add_owner(IN p_owner_id integer, IN p_owner_firstname character varying, IN p_owner_lastname character varying, IN p_owner_phone character, IN p_owner_email character varying, IN p_image text);
       public               postgres    false                       1255    16841 �   add_realty(integer, text, double precision, integer, double precision, integer, integer, integer, text, text, integer, text, text) 	   PROCEDURE     �  CREATE PROCEDURE public.add_realty(IN p_realty_id integer, IN p_realty_address text, IN p_realty_price double precision, IN p_realty_type_id integer, IN p_realty_area double precision, IN p_realty_rooms integer, IN p_realty_status_id integer, IN p_owner_id integer, IN p_image text, IN p_url text, IN p_floor integer, IN p_underground text, IN p_residential_complex text)
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO realty (
		realty_id,
    	realty_address, 
   	 	realty_price, 
   		realty_type_id, 
   	 	realty_area, 
    	realty_rooms,
		realty_status_id,
		owner_id,
        image,
		url,
    	floor,
    underground,
    residential_complex
    ) VALUES (
		p_realty_id,
        p_realty_address, 
        p_realty_price, 
        p_realty_type_id, 
        p_realty_area, 
        p_realty_rooms, 
        p_realty_status_id, 
		p_owner_id,
        p_image,
		p_url,
   		p_floor,
    	p_underground,
 	   p_residential_complex
    );
END $$;
 s  DROP PROCEDURE public.add_realty(IN p_realty_id integer, IN p_realty_address text, IN p_realty_price double precision, IN p_realty_type_id integer, IN p_realty_area double precision, IN p_realty_rooms integer, IN p_realty_status_id integer, IN p_owner_id integer, IN p_image text, IN p_url text, IN p_floor integer, IN p_underground text, IN p_residential_complex text);
       public               postgres    false                       1255    16933    avg_agent_amount()    FUNCTION     �   CREATE FUNCTION public.avg_agent_amount() RETURNS integer
    LANGUAGE plpgsql
    AS $$
DECLARE
    avg_amount int;
BEGIN
    SELECT ROUND(avg(agent_amount))::integer INTO avg_amount FROM agents;
    RETURN avg_amount;
END;
$$;
 )   DROP FUNCTION public.avg_agent_amount();
       public               postgres    false                       1255    16929    avg_realty_1room_type_flat()    FUNCTION     *  CREATE FUNCTION public.avg_realty_1room_type_flat() RETURNS integer
    LANGUAGE plpgsql
    AS $$
DECLARE
    room_count integer;
BEGIN
    SELECT ROUND(avg(realty_price))::integer INTO room_count
    FROM realty
    WHERE realty_rooms = 1 AND realty_type_id = 1;

    RETURN room_count;
END;
$$;
 3   DROP FUNCTION public.avg_realty_1room_type_flat();
       public               postgres    false                        1255    16932    avg_realty_2room_type_flat()    FUNCTION     *  CREATE FUNCTION public.avg_realty_2room_type_flat() RETURNS integer
    LANGUAGE plpgsql
    AS $$
DECLARE
    room_count integer;
BEGIN
    SELECT ROUND(avg(realty_price))::integer INTO room_count
    FROM realty
    WHERE realty_rooms = 2 AND realty_type_id = 1;

    RETURN room_count;
END;
$$;
 3   DROP FUNCTION public.avg_realty_2room_type_flat();
       public               postgres    false            �            1255    16931    avg_realty_3room_type_flat()    FUNCTION     *  CREATE FUNCTION public.avg_realty_3room_type_flat() RETURNS integer
    LANGUAGE plpgsql
    AS $$
DECLARE
    room_count integer;
BEGIN
    SELECT ROUND(avg(realty_price))::integer INTO room_count
    FROM realty
    WHERE realty_rooms = 3 AND realty_type_id = 1;

    RETURN room_count;
END;
$$;
 3   DROP FUNCTION public.avg_realty_3room_type_flat();
       public               postgres    false            �            1255    16930    avg_realty_4room_type_flat()    FUNCTION     *  CREATE FUNCTION public.avg_realty_4room_type_flat() RETURNS integer
    LANGUAGE plpgsql
    AS $$
DECLARE
    room_count integer;
BEGIN
    SELECT ROUND(avg(realty_price))::integer INTO room_count
    FROM realty
    WHERE realty_rooms = 4 AND realty_type_id = 1;

    RETURN room_count;
END;
$$;
 3   DROP FUNCTION public.avg_realty_4room_type_flat();
       public               postgres    false            �            1255    16858    avg_realty_5room_type_house()    FUNCTION     !  CREATE FUNCTION public.avg_realty_5room_type_house() RETURNS numeric
    LANGUAGE plpgsql
    AS $$
DECLARE
    room_count decimal(10,2);
BEGIN
    SELECT avg(realty_price) INTO room_count
    FROM realty
    WHERE realty_rooms = 5 AND realty_type_id = 2;

    RETURN room_count;
END;
$$;
 4   DROP FUNCTION public.avg_realty_5room_type_house();
       public               postgres    false            �            1255    16859    avg_realty_6room_type_house()    FUNCTION     !  CREATE FUNCTION public.avg_realty_6room_type_house() RETURNS numeric
    LANGUAGE plpgsql
    AS $$
DECLARE
    room_count decimal(10,2);
BEGIN
    SELECT avg(realty_price) INTO room_count
    FROM realty
    WHERE realty_rooms = 6 AND realty_type_id = 2;

    RETURN room_count;
END;
$$;
 4   DROP FUNCTION public.avg_realty_6room_type_house();
       public               postgres    false            �            1255    16860    avg_realty_7room_type_house()    FUNCTION     !  CREATE FUNCTION public.avg_realty_7room_type_house() RETURNS numeric
    LANGUAGE plpgsql
    AS $$
DECLARE
    room_count decimal(10,2);
BEGIN
    SELECT avg(realty_price) INTO room_count
    FROM realty
    WHERE realty_rooms = 7 AND realty_type_id = 2;

    RETURN room_count;
END;
$$;
 4   DROP FUNCTION public.avg_realty_7room_type_house();
       public               postgres    false            �            1255    16861    avg_realty_8room_type_house()    FUNCTION     !  CREATE FUNCTION public.avg_realty_8room_type_house() RETURNS numeric
    LANGUAGE plpgsql
    AS $$
DECLARE
    room_count decimal(10,2);
BEGIN
    SELECT avg(realty_price) INTO room_count
    FROM realty
    WHERE realty_rooms = 8 AND realty_type_id = 2;

    RETURN room_count;
END;
$$;
 4   DROP FUNCTION public.avg_realty_8room_type_house();
       public               postgres    false                       1255    16800    count_agents()    FUNCTION     �   CREATE FUNCTION public.count_agents() RETURNS integer
    LANGUAGE plpgsql
    AS $$
DECLARE
    total_agents integer;
BEGIN
    SELECT COUNT(*) INTO total_agents FROM agents;
    RETURN total_agents;
END;
$$;
 %   DROP FUNCTION public.count_agents();
       public               postgres    false                       1255    16848 "   count_realty_by_flat_and_status1()    FUNCTION     '  CREATE FUNCTION public.count_realty_by_flat_and_status1() RETURNS integer
    LANGUAGE plpgsql
    AS $$
DECLARE
    property_count integer;
BEGIN
    SELECT COUNT(*) INTO property_count
    FROM realty
    WHERE realty_type_id = 1 AND realty_status_id = 1;

    RETURN property_count;
END;
$$;
 9   DROP FUNCTION public.count_realty_by_flat_and_status1();
       public               postgres    false                       1255    16849 "   count_realty_by_flat_and_status2()    FUNCTION     '  CREATE FUNCTION public.count_realty_by_flat_and_status2() RETURNS integer
    LANGUAGE plpgsql
    AS $$
DECLARE
    property_count integer;
BEGIN
    SELECT COUNT(*) INTO property_count
    FROM realty
    WHERE realty_type_id = 1 AND realty_status_id = 2;

    RETURN property_count;
END;
$$;
 9   DROP FUNCTION public.count_realty_by_flat_and_status2();
       public               postgres    false                       1255    16850 "   count_realty_by_flat_and_status3()    FUNCTION     '  CREATE FUNCTION public.count_realty_by_flat_and_status3() RETURNS integer
    LANGUAGE plpgsql
    AS $$
DECLARE
    property_count integer;
BEGIN
    SELECT COUNT(*) INTO property_count
    FROM realty
    WHERE realty_type_id = 1 AND realty_status_id = 3;

    RETURN property_count;
END;
$$;
 9   DROP FUNCTION public.count_realty_by_flat_and_status3();
       public               postgres    false                       1255    16851 #   count_realty_by_house_and_status1()    FUNCTION     (  CREATE FUNCTION public.count_realty_by_house_and_status1() RETURNS integer
    LANGUAGE plpgsql
    AS $$
DECLARE
    property_count integer;
BEGIN
    SELECT COUNT(*) INTO property_count
    FROM realty
    WHERE realty_type_id = 2 AND realty_status_id = 1;

    RETURN property_count;
END;
$$;
 :   DROP FUNCTION public.count_realty_by_house_and_status1();
       public               postgres    false                        1255    16852 #   count_realty_by_house_and_status2()    FUNCTION     (  CREATE FUNCTION public.count_realty_by_house_and_status2() RETURNS integer
    LANGUAGE plpgsql
    AS $$
DECLARE
    property_count integer;
BEGIN
    SELECT COUNT(*) INTO property_count
    FROM realty
    WHERE realty_type_id = 2 AND realty_status_id = 2;

    RETURN property_count;
END;
$$;
 :   DROP FUNCTION public.count_realty_by_house_and_status2();
       public               postgres    false            !           1255    16853 #   count_realty_by_house_and_status3()    FUNCTION     (  CREATE FUNCTION public.count_realty_by_house_and_status3() RETURNS integer
    LANGUAGE plpgsql
    AS $$
DECLARE
    property_count integer;
BEGIN
    SELECT COUNT(*) INTO property_count
    FROM realty
    WHERE realty_type_id = 2 AND realty_status_id = 3;

    RETURN property_count;
END;
$$;
 :   DROP FUNCTION public.count_realty_by_house_and_status3();
       public               postgres    false                       1255    16797    delete_agent_by_id(integer) 	   PROCEDURE     �   CREATE PROCEDURE public.delete_agent_by_id(IN agent_id_to_delete integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
    DELETE FROM agents WHERE agent_id = agent_id_to_delete;
END $$;
 I   DROP PROCEDURE public.delete_agent_by_id(IN agent_id_to_delete integer);
       public               postgres    false            �            1255    16757    delete_client_by_id(integer) 	   PROCEDURE     �   CREATE PROCEDURE public.delete_client_by_id(IN client_id_to_delete integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
    DELETE FROM clients WHERE client_id = client_id_to_delete;
END $$;
 K   DROP PROCEDURE public.delete_client_by_id(IN client_id_to_delete integer);
       public               postgres    false            )           1255    25750    delete_client_request(integer) 	   PROCEDURE     �   CREATE PROCEDURE public.delete_client_request(IN p_client_request_id integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
    DELETE FROM client_requests
    WHERE client_request_id = p_client_request_id;
END;
$$;
 M   DROP PROCEDURE public.delete_client_request(IN p_client_request_id integer);
       public               postgres    false            ;           1255    25759 "   delete_client_request_after_deal()    FUNCTION     �   CREATE FUNCTION public.delete_client_request_after_deal() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    DELETE FROM public.client_requests
    WHERE client_id = NEW.client_id;
    
    RETURN NEW;
END;
$$;
 9   DROP FUNCTION public.delete_client_request_after_deal();
       public               postgres    false            $           1255    16895    delete_deal_by_id(integer) 	   PROCEDURE     �   CREATE PROCEDURE public.delete_deal_by_id(IN deal_id_to_delete integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
    DELETE FROM deals WHERE deal_id = deal_id_to_delete;
END $$;
 G   DROP PROCEDURE public.delete_deal_by_id(IN deal_id_to_delete integer);
       public               postgres    false            -           1255    16918    delete_demand_by_id(integer) 	   PROCEDURE     �   CREATE PROCEDURE public.delete_demand_by_id(IN demand_id_to_delete integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
    DELETE FROM demands WHERE demand_id = demand_id_to_delete;
END $$;
 K   DROP PROCEDURE public.delete_demand_by_id(IN demand_id_to_delete integer);
       public               postgres    false            �            1255    16772    delete_owner_by_id(integer) 	   PROCEDURE     �   CREATE PROCEDURE public.delete_owner_by_id(IN owner_id_to_delete integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
    DELETE FROM owners WHERE owners.owner_id = owner_id_to_delete;
END $$;
 I   DROP PROCEDURE public.delete_owner_by_id(IN owner_id_to_delete integer);
       public               postgres    false                       1255    16843    delete_realty_by_id(integer) 	   PROCEDURE     �   CREATE PROCEDURE public.delete_realty_by_id(IN realty_id_to_delete integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
    DELETE FROM realty WHERE realty_id = realty_id_to_delete;
END $$;
 K   DROP PROCEDURE public.delete_realty_by_id(IN realty_id_to_delete integer);
       public               postgres    false            �            1255    16793 "   find_agent_by_password(text, text)    FUNCTION     P  CREATE FUNCTION public.find_agent_by_password(p_agent_password text, p_agent_login text) RETURNS TABLE(agent_id integer, agent_login text, agent_password text, agent_firstname character varying, agent_lastname character varying, agent_phone character, agent_experience integer, agent_email character varying, agent_birthday date, agent_hire_date date, agent_percent integer, agent_amount numeric, image text)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT *
    FROM agents
    WHERE agents.agent_password = p_agent_password and agents.agent_login = p_agent_login;
END;
$$;
 X   DROP FUNCTION public.find_agent_by_password(p_agent_password text, p_agent_login text);
       public               postgres    false            �            1255    16792 %   find_employee_by_password(text, text)    FUNCTION     \  CREATE FUNCTION public.find_employee_by_password(p_employee_password text, p_employee_login text) RETURNS TABLE(employee_id integer, employee_login text, employee_password text, employee_firstname character varying, employee_lastname character varying, employee_phone character, employee_experience integer, employee_email character varying, employee_birthday date, employee_hire_date date, image text)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT *
    FROM employee
    WHERE employee.employee_password = p_employee_password and employee.employee_login = p_employee_login;
END;
$$;
 a   DROP FUNCTION public.find_employee_by_password(p_employee_password text, p_employee_login text);
       public               postgres    false            5           1255    16935 [   get_all_realty_info_filtered(integer, integer, numeric, numeric, numeric, numeric, integer)    FUNCTION     `  CREATE FUNCTION public.get_all_realty_info_filtered(p_type_id integer DEFAULT NULL::integer, p_status_id integer DEFAULT NULL::integer, p_min_price numeric DEFAULT NULL::numeric, p_max_price numeric DEFAULT NULL::numeric, p_min_area numeric DEFAULT NULL::numeric, p_max_area numeric DEFAULT NULL::numeric, p_rooms integer DEFAULT NULL::integer) RETURNS TABLE(realty_id integer, realty_address text, realty_price numeric, realty_type character varying, realty_status_text character varying, realty_area numeric, realty_rooms integer, owner_phone character, image text, url text, floor integer, underground character varying, residential_complex character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT 
        r.realty_id,
        r.realty_address,
        r.realty_price,
        rt.realty_type_text,
        rs.realty_status_text,
        r.realty_area,
        r.realty_rooms,
        o.owner_phone,
        COALESCE(r.image, '') AS image,
        COALESCE(r.url, '') AS url,
        COALESCE(r.floor, 0) AS floor,
        COALESCE(r.underground, '') AS underground,
        COALESCE(r.residential_complex, '') AS residential_complex
    FROM realty r
    INNER JOIN realty_type rt ON r.realty_type_id = rt.realty_type_id
    INNER JOIN realty_status rs ON r.realty_status_id = rs.realty_status_id
    INNER JOIN owners o ON r.owner_id = o.owner_id
    WHERE (p_type_id IS NULL OR r.realty_type_id = p_type_id)
      AND (p_status_id IS NULL OR r.realty_status_id = p_status_id)
      AND (p_min_price IS NULL OR r.realty_price >= p_min_price)
      AND (p_max_price IS NULL OR r.realty_price <= p_max_price)
      AND (p_min_area IS NULL OR r.realty_area >= p_min_area)
      AND (p_max_area IS NULL OR r.realty_area <= p_max_area)
      AND (p_rooms IS NULL OR (p_rooms < 4 AND r.realty_rooms = p_rooms) OR (p_rooms = 4 AND r.realty_rooms >= 4));
END;
$$;
 �   DROP FUNCTION public.get_all_realty_info_filtered(p_type_id integer, p_status_id integer, p_min_price numeric, p_max_price numeric, p_min_area numeric, p_max_area numeric, p_rooms integer);
       public               postgres    false                       1255    16799    get_avg_agent_percent()    FUNCTION     �   CREATE FUNCTION public.get_avg_agent_percent() RETURNS numeric
    LANGUAGE plpgsql
    AS $$
DECLARE
    avg_percent numeric;
BEGIN
    SELECT ROUND(AVG(agent_percent), 1) INTO avg_percent FROM agents;

    RETURN avg_percent;
END;
$$;
 .   DROP FUNCTION public.get_avg_agent_percent();
       public               postgres    false            <           1255    25747    get_client_requests()    FUNCTION     �  CREATE FUNCTION public.get_client_requests() RETURNS TABLE(client_request_id integer, client_id integer, realty_id integer, client_firstname character varying, client_lastname character varying, realty_address text, request_date date)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT
	client_requests.client_request_id,
		clients.client_id,
		realty.realty_id,
	clients.client_firstname,
	clients.client_lastname,
	realty.realty_address,
	client_requests.request_date
    FROM
        client_requests 
    INNER JOIN
        clients on client_requests.client_id = clients.client_id
    INNER JOIN
        realty ON client_requests.realty_id = realty.realty_id
		ORDER BY client_request_id DESC;
END;
$$;
 ,   DROP FUNCTION public.get_client_requests();
       public               postgres    false            :           1255    25758    get_clients_by_id(integer)    FUNCTION       CREATE FUNCTION public.get_clients_by_id(p_id integer) RETURNS TABLE(client_id integer, client_firstname character varying, client_lastname character varying, client_phone character, client_email character varying, image text)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT 
        c.client_id,
        c.client_firstname,
        c.client_lastname,
        c.client_phone,
        c.client_email,
        c.image
    FROM public.clients c
    WHERE c.client_id = p_id
    ORDER BY c.client_id;
END;
$$;
 6   DROP FUNCTION public.get_clients_by_id(p_id integer);
       public               postgres    false            3           1255    16939    get_deal_info()    FUNCTION     �  CREATE FUNCTION public.get_deal_info() RETURNS TABLE(deal_id integer, realty_image text, owner_firstname character varying, owner_lastname character varying, owner_phone character, owner_image text, client_firstname character varying, client_lastname character varying, client_phone character, client_image text, agent_firstname character varying, agent_lastname character varying, agent_phone character, agent_image text, deal_date date, deal_cost numeric)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT
        d.deal_id,
        r.image AS realty_image,
        o.owner_firstname,
        o.owner_lastname,
        o.owner_phone,
        o.image AS owner_image,
        c.client_firstname,
        c.client_lastname,
        c.client_phone,
        c.image AS client_image,
        a.agent_firstname,
        a.agent_lastname,
        a.agent_phone,
        a.image AS agent_image,
        d.deal_date,
        d.deal_cost
    FROM
        deals d
    JOIN realty r ON d.realty_id = r.realty_id
    JOIN clients c ON d.client_id = c.client_id
    JOIN agents a ON d.agent_id = a.agent_id
    JOIN owners o ON r.owner_id = o.owner_id;
END;
$$;
 &   DROP FUNCTION public.get_deal_info();
       public               postgres    false            ,           1255    16917    get_demands_info()    FUNCTION       CREATE FUNCTION public.get_demands_info() RETURNS TABLE(demand_id integer, client_id integer, client_firstname character varying, client_lastname character varying, client_phone character, image text, realty_type_text character varying, demand_cost bigint, demand_square integer, demand_rooms integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT d.demand_id,
			c.client_id,
           c.client_firstname,
           c.client_lastname,
		   c.client_phone,
           c.image,
           rt.realty_type_text,
           d.demand_cost,
           d.demand_square,
           d.demand_rooms
    FROM demands d
    INNER JOIN clients c ON d.client_id = c.client_id
    INNER JOIN realty_type rt ON d.realty_type_id = rt.realty_type_id
	order by demand_id asc;
END;
$$;
 )   DROP FUNCTION public.get_demands_info();
       public               postgres    false            9           1255    25757    get_owner_by_phone(character)    FUNCTION     �  CREATE FUNCTION public.get_owner_by_phone(p_owner_phone character) RETURNS TABLE(owner_id integer, owner_firstname character varying, owner_lastname character varying, owner_phone character, owner_email character varying, image text)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT 
        o.owner_id,
        o.owner_firstname,
        o.owner_lastname,
        o.owner_phone,
        o.owner_email,
        o.image
    FROM public.owners o
    WHERE o.owner_phone = p_owner_phone;
END;
$$;
 B   DROP FUNCTION public.get_owner_by_phone(p_owner_phone character);
       public               postgres    false            �            1255    16768     get_owner_id_by_phone(character)    FUNCTION     �   CREATE FUNCTION public.get_owner_id_by_phone(phone_number character) RETURNS integer
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN (
        SELECT owner_id
        FROM owners
        WHERE owner_phone = phone_number
    );
END;
$$;
 D   DROP FUNCTION public.get_owner_id_by_phone(phone_number character);
       public               postgres    false            8           1255    25756    get_realty_by_id(integer)    FUNCTION     �  CREATE FUNCTION public.get_realty_by_id(p_realty_id integer) RETURNS TABLE(realty_id integer, realty_address text, realty_price numeric, realty_type character varying, realty_status_text character varying, realty_area numeric, realty_rooms integer, owner_phone character, image text, url text, floor integer, underground character varying, residential_complex character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT 
         r.realty_id,
        r.realty_address,
        r.realty_price,
		rt.realty_type_text,
        rs.realty_status_text,
        r.realty_area,
        r.realty_rooms,
        o.owner_phone,
		r.image,
		r.url,
	    r.floor,
	    r.underground,
	    r.residential_complex
    FROM
        realty r
    INNER JOIN
        realty_status rs ON r.realty_status_id = rs.realty_status_id
    INNER JOIN
        owners o ON r.owner_id = o.owner_id
	INNER JOIN
        realty_type rt ON r.realty_type_id = rt.realty_type_id
    WHERE r.realty_id = p_realty_id;
END;
$$;
 <   DROP FUNCTION public.get_realty_by_id(p_realty_id integer);
       public               postgres    false                       1255    16844    get_realty_info()    FUNCTION     �  CREATE FUNCTION public.get_realty_info() RETURNS TABLE(realty_id integer, realty_address text, realty_price numeric, realty_type character varying, realty_status_text character varying, realty_area numeric, realty_rooms integer, owner_phone character, image text, url text, floor integer, underground character varying, residential_complex character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT
        r.realty_id,
        r.realty_address,
        r.realty_price,
		rt.realty_type_text,
        rs.realty_status_text,
        r.realty_area,
        r.realty_rooms,
        o.owner_phone,
		r.image,
		r.url,
	    r.floor,
	    r.underground,
	    r.residential_complex
    FROM
        realty r
    INNER JOIN
        realty_status rs ON r.realty_status_id = rs.realty_status_id
    INNER JOIN
        owners o ON r.owner_id = o.owner_id
	INNER JOIN
        realty_type rt ON r.realty_type_id = rt.realty_type_id
		ORDER BY r.realty_id ASC;
END;
$$;
 (   DROP FUNCTION public.get_realty_info();
       public               postgres    false                       1255    16847 )   get_realty_info_by_both(integer, integer)    FUNCTION     ]  CREATE FUNCTION public.get_realty_info_by_both(p_realty_type integer, p_realty_status integer) RETURNS TABLE(realty_id integer, realty_address text, realty_price numeric, realty_type character varying, realty_status_text character varying, realty_area numeric, realty_rooms integer, owner_phone character, image text, url text, floor integer, underground character varying, residential_complex character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT
        r.realty_id,
        r.realty_address,
        r.realty_price,
		rt.realty_type_text,
        rs.realty_status_text,
        r.realty_area,
        r.realty_rooms,
        o.owner_phone,
		r.image,
		r.url,
	    r.floor,
	    r.underground,
	    r.residential_complex
    FROM
        realty r
    INNER JOIN
        realty_status rs ON r.realty_status_id = rs.realty_status_id
    INNER JOIN
        owners o ON r.owner_id = o.owner_id
	INNER JOIN
        realty_type rt ON r.realty_type_id = rt.realty_type_id
		where r.realty_status_id = p_realty_status and r.realty_type_id = p_realty_type
		ORDER BY r.realty_id ASC;
END;
$$;
 ^   DROP FUNCTION public.get_realty_info_by_both(p_realty_type integer, p_realty_status integer);
       public               postgres    false                       1255    16846 "   get_realty_info_by_status(integer)    FUNCTION       CREATE FUNCTION public.get_realty_info_by_status(p_realty_type integer) RETURNS TABLE(realty_id integer, realty_address text, realty_price numeric, realty_type character varying, realty_status_text character varying, realty_area numeric, realty_rooms integer, owner_phone character, image text, url text, floor integer, underground character varying, residential_complex character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT
        r.realty_id,
        r.realty_address,
        r.realty_price,
		rt.realty_type_text,
        rs.realty_status_text,
        r.realty_area,
        r.realty_rooms,
        o.owner_phone,
		r.image,
		r.url,
	    r.floor,
	    r.underground,
	    r.residential_complex
    FROM
        realty r
    INNER JOIN
        realty_status rs ON r.realty_status_id = rs.realty_status_id
    INNER JOIN
        owners o ON r.owner_id = o.owner_id
	INNER JOIN
        realty_type rt ON r.realty_type_id = rt.realty_type_id
		where r.realty_status_id = p_realty_type
		ORDER BY r.realty_id ASC;
END;
$$;
 G   DROP FUNCTION public.get_realty_info_by_status(p_realty_type integer);
       public               postgres    false                       1255    16845     get_realty_info_by_type(integer)    FUNCTION       CREATE FUNCTION public.get_realty_info_by_type(p_realty_type integer) RETURNS TABLE(realty_id integer, realty_address text, realty_price numeric, realty_type character varying, realty_status_text character varying, realty_area numeric, realty_rooms integer, owner_phone character, image text, url text, floor integer, underground character varying, residential_complex character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT
        r.realty_id,
        r.realty_address,
        r.realty_price,
		rt.realty_type_text,
        rs.realty_status_text,
        r.realty_area,
        r.realty_rooms,
        o.owner_phone,
		r.image,
		r.url,
	    r.floor,
	    r.underground,
	    r.residential_complex
    FROM
        realty r
    INNER JOIN
        realty_status rs ON r.realty_status_id = rs.realty_status_id
    INNER JOIN
        owners o ON r.owner_id = o.owner_id
	INNER JOIN
        realty_type rt ON r.realty_type_id = rt.realty_type_id
		where r.realty_type_id = p_realty_type
		ORDER BY r.realty_id ASC;
END;
$$;
 E   DROP FUNCTION public.get_realty_info_by_type(p_realty_type integer);
       public               postgres    false            4           1255    16928 B   get_realty_info_filtered_paged(integer, integer, integer, integer)    FUNCTION       CREATE FUNCTION public.get_realty_info_filtered_paged(p_page integer, p_page_size integer, p_type_id integer DEFAULT NULL::integer, p_status_id integer DEFAULT NULL::integer) RETURNS TABLE(realty_id integer, realty_address text, realty_price numeric, realty_type character varying, realty_status_text character varying, realty_area numeric, realty_rooms integer, owner_phone character, image text, url text, floor integer, underground character varying, residential_complex character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT          r.realty_id,
        r.realty_address,
        r.realty_price,
		rt.realty_type_text,
        rs.realty_status_text,
        r.realty_area,
        r.realty_rooms,
        o.owner_phone,
		r.image,
		r.url,
	    r.floor,
	    r.underground,
	    r.residential_complex
    FROM realty r
	    INNER JOIN
        realty_status rs ON r.realty_status_id = rs.realty_status_id
    INNER JOIN
        owners o ON r.owner_id = o.owner_id
	INNER JOIN
        realty_type rt ON r.realty_type_id = rt.realty_type_id
    WHERE (p_type_id IS NULL OR r.realty_type_id = p_type_id)
      AND (p_status_id IS NULL OR r.realty_status_id = p_status_id)
    ORDER BY r.realty_id
    LIMIT p_page_size OFFSET (p_page - 1) * p_page_size;
END;
$$;
 �   DROP FUNCTION public.get_realty_info_filtered_paged(p_page integer, p_page_size integer, p_type_id integer, p_status_id integer);
       public               postgres    false            7           1255    16937 o   get_realty_info_filtered_paged(integer, integer, integer, integer, numeric, numeric, numeric, numeric, integer)    FUNCTION     �  CREATE FUNCTION public.get_realty_info_filtered_paged(p_page integer, p_page_size integer, p_type_id integer DEFAULT NULL::integer, p_status_id integer DEFAULT NULL::integer, p_min_price numeric DEFAULT NULL::numeric, p_max_price numeric DEFAULT NULL::numeric, p_min_area numeric DEFAULT NULL::numeric, p_max_area numeric DEFAULT NULL::numeric, p_rooms integer DEFAULT NULL::integer) RETURNS TABLE(realty_id integer, realty_address text, realty_price numeric, realty_type character varying, realty_status_text character varying, realty_area numeric, realty_rooms integer, owner_phone character, image text, url text, floor integer, underground character varying, residential_complex character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT 
        r.realty_id,
        r.realty_address,
        r.realty_price,
        rt.realty_type_text,
        rs.realty_status_text,
        r.realty_area,
        r.realty_rooms,
        o.owner_phone,
        COALESCE(r.image, '') AS image,
        COALESCE(r.url, '') AS url,
        COALESCE(r.floor, 0) AS floor,
        COALESCE(r.underground, '') AS underground,
        COALESCE(r.residential_complex, '') AS residential_complex
    FROM realty r
    INNER JOIN realty_type rt ON r.realty_type_id = rt.realty_type_id
    INNER JOIN realty_status rs ON r.realty_status_id = rs.realty_status_id
    INNER JOIN owners o ON r.owner_id = o.owner_id
    WHERE (p_type_id IS NULL OR r.realty_type_id = p_type_id)
      AND (p_status_id IS NULL OR r.realty_status_id = p_status_id)
      AND (p_min_price IS NULL OR r.realty_price >= p_min_price)
      AND (p_max_price IS NULL OR r.realty_price <= p_max_price)
      AND (p_min_area IS NULL OR r.realty_area >= p_min_area)
      AND (p_max_area IS NULL OR r.realty_area <= p_max_area)
      AND (p_rooms IS NULL OR (p_rooms < 4 AND r.realty_rooms = p_rooms) OR (p_rooms = 4 AND r.realty_rooms >= 4))
    ORDER BY r.realty_id
    LIMIT p_page_size OFFSET (p_page - 1) * p_page_size;
END;
$$;
 �   DROP FUNCTION public.get_realty_info_filtered_paged(p_page integer, p_page_size integer, p_type_id integer, p_status_id integer, p_min_price numeric, p_max_price numeric, p_min_area numeric, p_max_area numeric, p_rooms integer);
       public               postgres    false            1           1255    16925 *   get_total_realties_count(integer, integer)    FUNCTION     �  CREATE FUNCTION public.get_total_realties_count(p_type_id integer DEFAULT NULL::integer, p_status_id integer DEFAULT NULL::integer) RETURNS integer
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN (
        SELECT COUNT(*)
        FROM realty
        WHERE (p_type_id IS NULL OR realty_type_id = p_type_id)
          AND (p_status_id IS NULL OR realty_status_id = p_status_id)
    );
END;
$$;
 W   DROP FUNCTION public.get_total_realties_count(p_type_id integer, p_status_id integer);
       public               postgres    false            6           1255    16936 `   get_total_realties_count_filtered(integer, integer, numeric, numeric, numeric, numeric, integer)    FUNCTION     �  CREATE FUNCTION public.get_total_realties_count_filtered(p_type_id integer DEFAULT NULL::integer, p_status_id integer DEFAULT NULL::integer, p_min_price numeric DEFAULT NULL::numeric, p_max_price numeric DEFAULT NULL::numeric, p_min_area numeric DEFAULT NULL::numeric, p_max_area numeric DEFAULT NULL::numeric, p_rooms integer DEFAULT NULL::integer) RETURNS integer
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN (
        SELECT COUNT(*)
        FROM realty r
        INNER JOIN realty_type rt ON r.realty_type_id = rt.realty_type_id
        INNER JOIN realty_status rs ON r.realty_status_id = rs.realty_status_id
        INNER JOIN owners o ON r.owner_id = o.owner_id
        WHERE (p_type_id IS NULL OR r.realty_type_id = p_type_id)
          AND (p_status_id IS NULL OR r.realty_status_id = p_status_id)
          AND (p_min_price IS NULL OR r.realty_price >= p_min_price)
          AND (p_max_price IS NULL OR r.realty_price <= p_max_price)
          AND (p_min_area IS NULL OR r.realty_area >= p_min_area)
          AND (p_max_area IS NULL OR r.realty_area <= p_max_area)
          AND (p_rooms IS NULL OR (p_rooms < 4 AND r.realty_rooms = p_rooms) OR (p_rooms = 4 AND r.realty_rooms >= 4))
    );
END;
$$;
 �   DROP FUNCTION public.get_total_realties_count_filtered(p_type_id integer, p_status_id integer, p_min_price numeric, p_max_price numeric, p_min_area numeric, p_max_area numeric, p_rooms integer);
       public               postgres    false            �            1255    16755    list_clients_sorted_by_id()    FUNCTION     X  CREATE FUNCTION public.list_clients_sorted_by_id() RETURNS TABLE(client_id integer, client_firstname character varying, client_lastname character varying, client_phone character, client_email character varying, image text)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT *
    FROM clients
    ORDER BY client_id ASC;
END;
$$;
 2   DROP FUNCTION public.list_clients_sorted_by_id();
       public               postgres    false                       1255    16798    list_employees_sorted_by_id()    FUNCTION     �  CREATE FUNCTION public.list_employees_sorted_by_id() RETURNS TABLE(agent_id integer, agent_login text, agent_password text, agent_firstname character varying, agent_lastname character varying, agent_phone character, agent_experience integer, agent_email character varying, agent_birthday date, agent_hire_date date, agent_percent integer, agent_amount numeric, image text)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT *
    FROM agents
    ORDER BY agent_id ASC;
END;
$$;
 4   DROP FUNCTION public.list_employees_sorted_by_id();
       public               postgres    false            �            1255    16769    list_owners_sorted_by_id()    FUNCTION     P  CREATE FUNCTION public.list_owners_sorted_by_id() RETURNS TABLE(owner_id integer, owner_firstname character varying, owner_lastname character varying, owner_phone character, owner_email character varying, image text)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT *
    FROM owners
    ORDER BY owner_id ASC;
END;
$$;
 1   DROP FUNCTION public.list_owners_sorted_by_id();
       public               postgres    false            �            1255    16794 -   search_agents_by_last_name(character varying)    FUNCTION     c  CREATE FUNCTION public.search_agents_by_last_name(last_name_search character varying) RETURNS TABLE(agent_id integer, agent_login text, agent_password text, agent_firstname character varying, agent_lastname character varying, agent_phone character, agent_experience integer, agent_email character varying, agent_birthday date, agent_hire_date date, agent_percent integer, agent_amount numeric, image text)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
        SELECT *
        FROM agents
        WHERE agents.agent_lastname ILIKE '%' || last_name_search || '%'
		ORDER BY agents.agent_id ASC;
END;
$$;
 U   DROP FUNCTION public.search_agents_by_last_name(last_name_search character varying);
       public               postgres    false            =           1255    25762 %   search_client_requests_by_query(text)    FUNCTION     C  CREATE FUNCTION public.search_client_requests_by_query(query text) RETURNS TABLE(client_request_id integer, client_id integer, realty_id integer, client_firstname character varying, client_lastname character varying, realty_address text, request_date date)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT
        cr.client_request_id,
        c.client_id,
        r.realty_id,
        c.client_firstname,
        c.client_lastname,
        r.realty_address,
        cr.request_date
    FROM
        client_requests cr
    INNER JOIN
        clients c ON cr.client_id = c.client_id
    INNER JOIN
        realty r ON cr.realty_id = r.realty_id
    WHERE
        c.client_firstname ILIKE '%' || query || '%' OR
        c.client_lastname ILIKE '%' || query || '%'
    ORDER BY
        cr.client_request_id DESC;
END;
$$;
 B   DROP FUNCTION public.search_client_requests_by_query(query text);
       public               postgres    false            �            1255    16758 .   search_clients_by_last_name(character varying)    FUNCTION     �  CREATE FUNCTION public.search_clients_by_last_name(last_name_search character varying) RETURNS TABLE(client_id integer, client_firstname character varying, client_lastname character varying, client_phone character, client_email character varying, image text)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
        SELECT *
        FROM clients
        WHERE clients.client_lastname ILIKE '%' || last_name_search || '%'
		ORDER BY clients.client_id ASC;
END;
$$;
 V   DROP FUNCTION public.search_clients_by_last_name(last_name_search character varying);
       public               postgres    false            #           1255    16894 "   search_deal_by_both(text, integer)    FUNCTION     �  CREATE FUNCTION public.search_deal_by_both(last_name_search text, status_search integer) RETURNS TABLE(deal_id integer, realty_image text, owner_firstname character varying, owner_lastname character varying, owner_phone character, owner_image text, client_firstname character varying, client_lastname character varying, client_phone character, client_image text, agent_firstname character varying, agent_lastname character varying, agent_phone character, agent_image text, realty_status_text character varying, deal_date date, deal_cost numeric)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT
        d.deal_id,
        r.image AS realty_image,
        o.owner_firstname,
        o.owner_lastname,
        o.owner_phone,
        o.image AS owner_image,
        c.client_firstname,
        c.client_lastname,
        c.client_phone,
        c.image AS client_image,
        a.agent_firstname,
        a.agent_lastname,
        a.agent_phone,
        a.image AS agent_image,
        rs.realty_status_text,
        d.deal_date,
        d.deal_cost
    FROM
        deals d
    JOIN realty r ON d.realty_id = r.realty_id
    JOIN clients c ON d.client_id = c.client_id
    JOIN agents a ON d.agent_id = a.agent_id
    JOIN owners o ON r.owner_id = o.owner_id
    JOIN realty_status rs ON d.realty_status_id = rs.realty_status_id
	WHERE c.client_lastname ILIKE '%' || last_name_search || '%' and rs.realty_status_id = status_search
		ORDER BY d.deal_id ASC;
END;
$$;
 X   DROP FUNCTION public.search_deal_by_both(last_name_search text, status_search integer);
       public               postgres    false            2           1255    16940 $   search_deal_by_client_lastname(text)    FUNCTION     	  CREATE FUNCTION public.search_deal_by_client_lastname(last_name_search text) RETURNS TABLE(deal_id integer, realty_image text, owner_firstname character varying, owner_lastname character varying, owner_phone character, owner_image text, client_firstname character varying, client_lastname character varying, client_phone character, client_image text, agent_firstname character varying, agent_lastname character varying, agent_phone character, agent_image text, deal_date date, deal_cost numeric)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT
        d.deal_id,
        r.image AS realty_image,
        o.owner_firstname,
        o.owner_lastname,
        o.owner_phone,
        o.image AS owner_image,
        c.client_firstname,
        c.client_lastname,
        c.client_phone,
        c.image AS client_image,
        a.agent_firstname,
        a.agent_lastname,
        a.agent_phone,
        a.image AS agent_image,
        d.deal_date,
        d.deal_cost
    FROM
        deals d
    JOIN realty r ON d.realty_id = r.realty_id
    JOIN clients c ON d.client_id = c.client_id
    JOIN agents a ON d.agent_id = a.agent_id
    JOIN owners o ON r.owner_id = o.owner_id
	WHERE c.client_lastname ILIKE '%' || last_name_search || '%'
		ORDER BY d.deal_id ASC;
END;
$$;
 L   DROP FUNCTION public.search_deal_by_client_lastname(last_name_search text);
       public               postgres    false            "           1255    16893    search_deal_by_status(integer)    FUNCTION     x  CREATE FUNCTION public.search_deal_by_status(status_search integer) RETURNS TABLE(deal_id integer, realty_image text, owner_firstname character varying, owner_lastname character varying, owner_phone character, owner_image text, client_firstname character varying, client_lastname character varying, client_phone character, client_image text, agent_firstname character varying, agent_lastname character varying, agent_phone character, agent_image text, realty_status_text character varying, deal_date date, deal_cost numeric)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT
        d.deal_id,
        r.image AS realty_image,
        o.owner_firstname,
        o.owner_lastname,
        o.owner_phone,
        o.image AS owner_image,
        c.client_firstname,
        c.client_lastname,
        c.client_phone,
        c.image AS client_image,
        a.agent_firstname,
        a.agent_lastname,
        a.agent_phone,
        a.image AS agent_image,
        rs.realty_status_text,
        d.deal_date,
        d.deal_cost
    FROM
        deals d
    JOIN realty r ON d.realty_id = r.realty_id
    JOIN clients c ON d.client_id = c.client_id
    JOIN agents a ON d.agent_id = a.agent_id
    JOIN owners o ON r.owner_id = o.owner_id
    JOIN realty_status rs ON d.realty_status_id = rs.realty_status_id
	WHERE rs.realty_status_id = status_search
		ORDER BY d.deal_id ASC;
END;
$$;
 C   DROP FUNCTION public.search_deal_by_status(status_search integer);
       public               postgres    false            0           1255    16921 $   search_demand_by_both(text, integer)    FUNCTION     �  CREATE FUNCTION public.search_demand_by_both(p_client_lastname text, p_realty_type integer) RETURNS TABLE(demand_id integer, client_id integer, client_firstname character varying, client_lastname character varying, client_phone character, image text, realty_type_text character varying, demand_cost bigint, demand_square integer, demand_rooms integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT d.demand_id,
			c.client_id,
           c.client_firstname,
           c.client_lastname,
		   c.client_phone,
           c.image,
           rt.realty_type_text,
           d.demand_cost,
           d.demand_square,
           d.demand_rooms
    FROM demands d
    INNER JOIN clients c ON d.client_id = c.client_id
    INNER JOIN realty_type rt ON d.realty_type_id = rt.realty_type_id
	WHERE c.client_lastname ILIKE '%' || p_client_lastname || '%' and rt.realty_type_id = p_realty_type
	order by demand_id asc;
END;
$$;
 [   DROP FUNCTION public.search_demand_by_both(p_client_lastname text, p_realty_type integer);
       public               postgres    false            .           1255    16919    search_demand_by_client(text)    FUNCTION     o  CREATE FUNCTION public.search_demand_by_client(p_client_lastname text) RETURNS TABLE(demand_id integer, client_id integer, client_firstname character varying, client_lastname character varying, client_phone character, image text, realty_type_text character varying, demand_cost bigint, demand_square integer, demand_rooms integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT d.demand_id,
			c.client_id,
           c.client_firstname,
           c.client_lastname,
		   c.client_phone,
           c.image,
           rt.realty_type_text,
           d.demand_cost,
           d.demand_square,
           d.demand_rooms
    FROM demands d
    INNER JOIN clients c ON d.client_id = c.client_id
    INNER JOIN realty_type rt ON d.realty_type_id = rt.realty_type_id
	WHERE c.client_lastname ILIKE '%' || p_client_lastname || '%'
	order by demand_id asc;
END;
$$;
 F   DROP FUNCTION public.search_demand_by_client(p_client_lastname text);
       public               postgres    false            /           1255    16920 %   search_demand_by_realty_type(integer)    FUNCTION     ]  CREATE FUNCTION public.search_demand_by_realty_type(p_realty_type integer) RETURNS TABLE(demand_id integer, client_id integer, client_firstname character varying, client_lastname character varying, client_phone character, image text, realty_type_text character varying, demand_cost bigint, demand_square integer, demand_rooms integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT d.demand_id,
			c.client_id,
           c.client_firstname,
           c.client_lastname,
		   c.client_phone,
           c.image,
           rt.realty_type_text,
           d.demand_cost,
           d.demand_square,
           d.demand_rooms
    FROM demands d
    INNER JOIN clients c ON d.client_id = c.client_id
    INNER JOIN realty_type rt ON d.realty_type_id = rt.realty_type_id
	WHERE rt.realty_type_id = p_realty_type
	order by demand_id asc;
END;
$$;
 J   DROP FUNCTION public.search_demand_by_realty_type(p_realty_type integer);
       public               postgres    false            �            1255    16773 -   search_owners_by_last_name(character varying)    FUNCTION     �  CREATE FUNCTION public.search_owners_by_last_name(last_name_search character varying) RETURNS TABLE(owner_id integer, owner_firstname character varying, owner_lastname character varying, owner_phone character, owner_email character varying, image text)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
        SELECT *
        FROM owners
        WHERE owners.owner_lastname ILIKE '%' || last_name_search || '%'
		ORDER BY owners.owner_id ASC;
END;
$$;
 U   DROP FUNCTION public.search_owners_by_last_name(last_name_search character varying);
       public               postgres    false            �            1255    16795 �   update_agent(integer, text, text, text, text, text, integer, text, timestamp without time zone, timestamp without time zone, integer, double precision) 	   PROCEDURE     b  CREATE PROCEDURE public.update_agent(IN p_agent_id integer, IN p_agent_login text, IN p_agent_password text, IN p_firstname text, IN p_lastname text, IN p_phone text, IN p_experience integer, IN p_email text, IN p_birthday timestamp without time zone, IN p_hire_date timestamp without time zone, IN p_percent integer, IN p_amount double precision)
    LANGUAGE plpgsql
    AS $$
BEGIN
    UPDATE agents
    SET
		agent_login = COALESCE(p_agent_login, agent_login),
		agent_password = COALESCE(p_agent_password, p_agent_password),
        agent_firstname = COALESCE(p_firstname, agent_firstname),
        agent_lastname = COALESCE(p_lastname, agent_lastname),
        agent_phone = COALESCE(p_phone, agent_phone),
        agent_experience = COALESCE(p_experience, agent_experience),
        agent_email = COALESCE(p_email, agent_email),
        agent_birthday = COALESCE(p_birthday, agent_birthday),
        agent_hire_date = COALESCE(p_hire_date, agent_hire_date),
        agent_percent = COALESCE(p_percent, agent_percent),
        agent_amount = COALESCE(p_amount, agent_amount)
    WHERE agent_id = p_agent_id;
END $$;
 [  DROP PROCEDURE public.update_agent(IN p_agent_id integer, IN p_agent_login text, IN p_agent_password text, IN p_firstname text, IN p_lastname text, IN p_phone text, IN p_experience integer, IN p_email text, IN p_birthday timestamp without time zone, IN p_hire_date timestamp without time zone, IN p_percent integer, IN p_amount double precision);
       public               postgres    false            &           1255    16898    update_agent_amount()    FUNCTION     1  CREATE FUNCTION public.update_agent_amount() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
DECLARE
    v_realty_status_id integer;
BEGIN
    -- Получаем текущий realty_status_id из таблицы realty
    SELECT realty_status_id INTO v_realty_status_id
    FROM realty
    WHERE realty_id = NEW.realty_id;

    -- Обновляем agent_amount в зависимости от realty_status_id
    IF v_realty_status_id = 2 THEN
        UPDATE agents
        SET agent_amount = COALESCE(agent_amount, 0) + (NEW.deal_cost * 0.5)
        WHERE agent_id = NEW.agent_id;
    ELSIF v_realty_status_id = 1 THEN
        UPDATE agents
        SET agent_amount = COALESCE(agent_amount, 0) + (NEW.deal_cost * agent_percent / 100)
        WHERE agent_id = NEW.agent_id;
    END IF;

    RETURN NEW;
END;
$$;
 ,   DROP FUNCTION public.update_agent_amount();
       public               postgres    false            �            1255    16756 .   update_client(integer, text, text, text, text) 	   PROCEDURE     �  CREATE PROCEDURE public.update_client(IN p_client_id integer, IN p_firstname text, IN p_lastname text, IN p_phone text, IN p_email text)
    LANGUAGE plpgsql
    AS $$
BEGIN
    UPDATE clients
    SET
        client_firstname = COALESCE(p_firstname, client_firstname),
        client_lastname = COALESCE(p_lastname, client_lastname),
        client_phone = COALESCE(p_phone, client_phone),
        client_email = COALESCE(p_email, client_email)
    WHERE client_id = p_client_id;
END $$;
 �   DROP PROCEDURE public.update_client(IN p_client_id integer, IN p_firstname text, IN p_lastname text, IN p_phone text, IN p_email text);
       public               postgres    false            *           1255    25752 0   update_client_request(integer, integer, integer) 	   PROCEDURE     C  CREATE PROCEDURE public.update_client_request(IN p_client_request_id integer, IN p_client_id integer, IN p_realty_id integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
    UPDATE client_requests
    SET
        client_id = p_client_id,
        realty_id = p_realty_id
    WHERE client_request_id = p_client_request_id;
END;
$$;
 }   DROP PROCEDURE public.update_client_request(IN p_client_request_id integer, IN p_client_id integer, IN p_realty_id integer);
       public               postgres    false            (           1255    25749 6   update_client_request(integer, integer, integer, date) 	   PROCEDURE     �  CREATE PROCEDURE public.update_client_request(IN p_client_request_id integer, IN p_client_id integer, IN p_realty_id integer, IN p_request_date date)
    LANGUAGE plpgsql
    AS $$
BEGIN
    UPDATE client_requests
    SET
        client_id = p_client_id,
        realty_id = p_realty_id,
        request_date = p_request_date
    WHERE client_request_id = p_client_request_id;
END;
$$;
 �   DROP PROCEDURE public.update_client_request(IN p_client_request_id integer, IN p_client_id integer, IN p_realty_id integer, IN p_request_date date);
       public               postgres    false            �            1255    16771 -   update_owner(integer, text, text, text, text) 	   PROCEDURE     �  CREATE PROCEDURE public.update_owner(IN p_owner_id integer, IN p_firstname text, IN p_lastname text, IN p_phone text, IN p_email text)
    LANGUAGE plpgsql
    AS $$
BEGIN
    UPDATE owners
    SET
        owner_firstname = COALESCE(p_firstname, owner_firstname),
        owner_lastname = COALESCE(p_lastname, owner_lastname),
        owner_phone = COALESCE(p_phone, owner_phone),
        owner_email = COALESCE(p_email, owner_email)
    WHERE owner_id = p_owner_id;
END $$;
 �   DROP PROCEDURE public.update_owner(IN p_owner_id integer, IN p_firstname text, IN p_lastname text, IN p_phone text, IN p_email text);
       public               postgres    false                       1255    16842    update_realty(integer, text, double precision, integer, double precision, integer, integer, integer, text, integer, text, text) 	   PROCEDURE     Q  CREATE PROCEDURE public.update_realty(IN p_realty_id integer, IN p_realty_address text, IN p_realty_price double precision, IN p_realty_type_id integer, IN p_realty_area double precision, IN p_realty_rooms integer, IN p_realty_status_id integer, IN p_owner_id integer, IN p_url text, IN p_floor integer, IN p_underground text, IN p_residential_complex text)
    LANGUAGE plpgsql
    AS $$
BEGIN
    UPDATE realty
    SET
        realty_address = COALESCE(p_realty_address, realty_address),
        realty_price = COALESCE(p_realty_price, realty_price),
        realty_type_id = COALESCE(p_realty_type_id, realty_type_id),
        realty_area = COALESCE(p_realty_area, realty_area),
        realty_rooms = COALESCE(p_realty_rooms, realty_rooms),
        realty_status_id = COALESCE(p_realty_status_id, realty_status_id),
		owner_id = COALESCE(p_owner_id, owner_id),
		url = COALESCE(p_url, url),
		floor = COALESCE(p_floor, floor),
		underground = COALESCE(p_underground, underground),
		residential_complex = COALESCE(p_residential_complex, residential_complex)
    WHERE realty_id = p_realty_id;
END $$;
 e  DROP PROCEDURE public.update_realty(IN p_realty_id integer, IN p_realty_address text, IN p_realty_price double precision, IN p_realty_type_id integer, IN p_realty_area double precision, IN p_realty_rooms integer, IN p_realty_status_id integer, IN p_owner_id integer, IN p_url text, IN p_floor integer, IN p_underground text, IN p_residential_complex text);
       public               postgres    false            %           1255    16896    update_realty_status()    FUNCTION       CREATE FUNCTION public.update_realty_status() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    -- Обновление статуса недвижимости
    UPDATE realty
    SET realty_status_id = 3
    WHERE realty_id = NEW.realty_id;

    RETURN NEW;
END;
$$;
 -   DROP FUNCTION public.update_realty_status();
       public               postgres    false            �            1259    16775    agents    TABLE     �  CREATE TABLE public.agents (
    agent_id integer NOT NULL,
    agent_login text,
    agent_password text,
    agent_firstname character varying(60) NOT NULL,
    agent_lastname character varying(60) NOT NULL,
    agent_phone character(11) NOT NULL,
    agent_experience integer NOT NULL,
    agent_email character varying(100) NOT NULL,
    agent_birthday date NOT NULL,
    agent_hire_date date NOT NULL,
    agent_percent integer NOT NULL,
    agent_amount numeric(10,2),
    image text
);
    DROP TABLE public.agents;
       public         heap r       postgres    false            �            1259    16774    agents_agent_id_seq    SEQUENCE     �   CREATE SEQUENCE public.agents_agent_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 *   DROP SEQUENCE public.agents_agent_id_seq;
       public               postgres    false    222            �           0    0    agents_agent_id_seq    SEQUENCE OWNED BY     K   ALTER SEQUENCE public.agents_agent_id_seq OWNED BY public.agents.agent_id;
          public               postgres    false    221            �            1259    25728    client_requests    TABLE     �   CREATE TABLE public.client_requests (
    client_request_id integer NOT NULL,
    client_id integer,
    realty_id integer,
    request_date date DEFAULT CURRENT_DATE
);
 #   DROP TABLE public.client_requests;
       public         heap r       postgres    false            �            1259    25727 %   client_requests_client_request_id_seq    SEQUENCE     �   CREATE SEQUENCE public.client_requests_client_request_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 <   DROP SEQUENCE public.client_requests_client_request_id_seq;
       public               postgres    false    234            �           0    0 %   client_requests_client_request_id_seq    SEQUENCE OWNED BY     o   ALTER SEQUENCE public.client_requests_client_request_id_seq OWNED BY public.client_requests.client_request_id;
          public               postgres    false    233            �            1259    16746    clients    TABLE       CREATE TABLE public.clients (
    client_id integer NOT NULL,
    client_firstname character varying(60) NOT NULL,
    client_lastname character varying(60) NOT NULL,
    client_phone character(11) NOT NULL,
    client_email character varying(100),
    image text
);
    DROP TABLE public.clients;
       public         heap r       postgres    false            �            1259    16745    clients_client_id_seq    SEQUENCE     �   CREATE SEQUENCE public.clients_client_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 ,   DROP SEQUENCE public.clients_client_id_seq;
       public               postgres    false    218            �           0    0    clients_client_id_seq    SEQUENCE OWNED BY     O   ALTER SEQUENCE public.clients_client_id_seq OWNED BY public.clients.client_id;
          public               postgres    false    217            �            1259    16863    deals    TABLE     �   CREATE TABLE public.deals (
    deal_id integer NOT NULL,
    realty_id integer,
    client_id integer,
    agent_id integer,
    deal_date date DEFAULT CURRENT_DATE,
    deal_cost numeric(10,2) NOT NULL
);
    DROP TABLE public.deals;
       public         heap r       postgres    false            �            1259    16862    deals_deal_id_seq    SEQUENCE     �   CREATE SEQUENCE public.deals_deal_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE public.deals_deal_id_seq;
       public               postgres    false    232            �           0    0    deals_deal_id_seq    SEQUENCE OWNED BY     G   ALTER SEQUENCE public.deals_deal_id_seq OWNED BY public.deals.deal_id;
          public               postgres    false    231            �            1259    16784    employee    TABLE     �  CREATE TABLE public.employee (
    employee_id integer NOT NULL,
    employee_login text,
    employee_password text,
    employee_firstname character varying(60) NOT NULL,
    employee_lastname character varying(60) NOT NULL,
    employee_phone character(11) NOT NULL,
    employee_experience integer NOT NULL,
    employee_email character varying(100) NOT NULL,
    employee_birthday date NOT NULL,
    employee_hire_date date NOT NULL,
    image text
);
    DROP TABLE public.employee;
       public         heap r       postgres    false            �            1259    16783    employee_employee_id_seq    SEQUENCE     �   CREATE SEQUENCE public.employee_employee_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 /   DROP SEQUENCE public.employee_employee_id_seq;
       public               postgres    false    224            �           0    0    employee_employee_id_seq    SEQUENCE OWNED BY     U   ALTER SEQUENCE public.employee_employee_id_seq OWNED BY public.employee.employee_id;
          public               postgres    false    223            �            1259    16760    owners    TABLE       CREATE TABLE public.owners (
    owner_id integer NOT NULL,
    owner_firstname character varying(60) NOT NULL,
    owner_lastname character varying(60) NOT NULL,
    owner_phone character(11) NOT NULL,
    owner_email character varying(100) NOT NULL,
    image text
);
    DROP TABLE public.owners;
       public         heap r       postgres    false            �            1259    16759    owners_owner_id_seq    SEQUENCE     �   CREATE SEQUENCE public.owners_owner_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 *   DROP SEQUENCE public.owners_owner_id_seq;
       public               postgres    false    220            �           0    0    owners_owner_id_seq    SEQUENCE OWNED BY     K   ALTER SEQUENCE public.owners_owner_id_seq OWNED BY public.owners.owner_id;
          public               postgres    false    219            �            1259    16818    realty    TABLE     �  CREATE TABLE public.realty (
    realty_id integer NOT NULL,
    realty_address text,
    realty_price numeric(15,2),
    realty_type_id integer,
    realty_area numeric(10,2),
    realty_rooms integer,
    realty_status_id integer,
    owner_id integer,
    image text,
    url text,
    floor integer,
    underground character varying(255),
    residential_complex character varying(255)
);
    DROP TABLE public.realty;
       public         heap r       postgres    false            �            1259    16817    realty_realty_id_seq    SEQUENCE     �   CREATE SEQUENCE public.realty_realty_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 +   DROP SEQUENCE public.realty_realty_id_seq;
       public               postgres    false    230            �           0    0    realty_realty_id_seq    SEQUENCE OWNED BY     M   ALTER SEQUENCE public.realty_realty_id_seq OWNED BY public.realty.realty_id;
          public               postgres    false    229            �            1259    16803    realty_status    TABLE     �   CREATE TABLE public.realty_status (
    realty_status_id integer NOT NULL,
    realty_status_text character varying(50) DEFAULT 'Купить'::character varying
);
 !   DROP TABLE public.realty_status;
       public         heap r       postgres    false            �            1259    16802 "   realty_status_realty_status_id_seq    SEQUENCE     �   CREATE SEQUENCE public.realty_status_realty_status_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 9   DROP SEQUENCE public.realty_status_realty_status_id_seq;
       public               postgres    false    226            �           0    0 "   realty_status_realty_status_id_seq    SEQUENCE OWNED BY     i   ALTER SEQUENCE public.realty_status_realty_status_id_seq OWNED BY public.realty_status.realty_status_id;
          public               postgres    false    225            �            1259    16811    realty_type    TABLE     ~   CREATE TABLE public.realty_type (
    realty_type_id integer NOT NULL,
    realty_type_text character varying(50) NOT NULL
);
    DROP TABLE public.realty_type;
       public         heap r       postgres    false            �            1259    16810    realty_type_realty_type_id_seq    SEQUENCE     �   CREATE SEQUENCE public.realty_type_realty_type_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 5   DROP SEQUENCE public.realty_type_realty_type_id_seq;
       public               postgres    false    228            �           0    0    realty_type_realty_type_id_seq    SEQUENCE OWNED BY     a   ALTER SEQUENCE public.realty_type_realty_type_id_seq OWNED BY public.realty_type.realty_type_id;
          public               postgres    false    227            �           2604    16778    agents agent_id    DEFAULT     r   ALTER TABLE ONLY public.agents ALTER COLUMN agent_id SET DEFAULT nextval('public.agents_agent_id_seq'::regclass);
 >   ALTER TABLE public.agents ALTER COLUMN agent_id DROP DEFAULT;
       public               postgres    false    222    221    222                        2604    25731 !   client_requests client_request_id    DEFAULT     �   ALTER TABLE ONLY public.client_requests ALTER COLUMN client_request_id SET DEFAULT nextval('public.client_requests_client_request_id_seq'::regclass);
 P   ALTER TABLE public.client_requests ALTER COLUMN client_request_id DROP DEFAULT;
       public               postgres    false    234    233    234            �           2604    16749    clients client_id    DEFAULT     v   ALTER TABLE ONLY public.clients ALTER COLUMN client_id SET DEFAULT nextval('public.clients_client_id_seq'::regclass);
 @   ALTER TABLE public.clients ALTER COLUMN client_id DROP DEFAULT;
       public               postgres    false    217    218    218            �           2604    16866    deals deal_id    DEFAULT     n   ALTER TABLE ONLY public.deals ALTER COLUMN deal_id SET DEFAULT nextval('public.deals_deal_id_seq'::regclass);
 <   ALTER TABLE public.deals ALTER COLUMN deal_id DROP DEFAULT;
       public               postgres    false    231    232    232            �           2604    16787    employee employee_id    DEFAULT     |   ALTER TABLE ONLY public.employee ALTER COLUMN employee_id SET DEFAULT nextval('public.employee_employee_id_seq'::regclass);
 C   ALTER TABLE public.employee ALTER COLUMN employee_id DROP DEFAULT;
       public               postgres    false    224    223    224            �           2604    16763    owners owner_id    DEFAULT     r   ALTER TABLE ONLY public.owners ALTER COLUMN owner_id SET DEFAULT nextval('public.owners_owner_id_seq'::regclass);
 >   ALTER TABLE public.owners ALTER COLUMN owner_id DROP DEFAULT;
       public               postgres    false    220    219    220            �           2604    16821    realty realty_id    DEFAULT     t   ALTER TABLE ONLY public.realty ALTER COLUMN realty_id SET DEFAULT nextval('public.realty_realty_id_seq'::regclass);
 ?   ALTER TABLE public.realty ALTER COLUMN realty_id DROP DEFAULT;
       public               postgres    false    229    230    230            �           2604    16806    realty_status realty_status_id    DEFAULT     �   ALTER TABLE ONLY public.realty_status ALTER COLUMN realty_status_id SET DEFAULT nextval('public.realty_status_realty_status_id_seq'::regclass);
 M   ALTER TABLE public.realty_status ALTER COLUMN realty_status_id DROP DEFAULT;
       public               postgres    false    225    226    226            �           2604    16814    realty_type realty_type_id    DEFAULT     �   ALTER TABLE ONLY public.realty_type ALTER COLUMN realty_type_id SET DEFAULT nextval('public.realty_type_realty_type_id_seq'::regclass);
 I   ALTER TABLE public.realty_type ALTER COLUMN realty_type_id DROP DEFAULT;
       public               postgres    false    227    228    228            �          0    16775    agents 
   TABLE DATA           �   COPY public.agents (agent_id, agent_login, agent_password, agent_firstname, agent_lastname, agent_phone, agent_experience, agent_email, agent_birthday, agent_hire_date, agent_percent, agent_amount, image) FROM stdin;
    public               postgres    false    222   %Y      �          0    25728    client_requests 
   TABLE DATA           `   COPY public.client_requests (client_request_id, client_id, realty_id, request_date) FROM stdin;
    public               postgres    false    234   \      �          0    16746    clients 
   TABLE DATA           r   COPY public.clients (client_id, client_firstname, client_lastname, client_phone, client_email, image) FROM stdin;
    public               postgres    false    218   W\      �          0    16863    deals 
   TABLE DATA           ^   COPY public.deals (deal_id, realty_id, client_id, agent_id, deal_date, deal_cost) FROM stdin;
    public               postgres    false    232   �^      �          0    16784    employee 
   TABLE DATA           �   COPY public.employee (employee_id, employee_login, employee_password, employee_firstname, employee_lastname, employee_phone, employee_experience, employee_email, employee_birthday, employee_hire_date, image) FROM stdin;
    public               postgres    false    224   #_      �          0    16760    owners 
   TABLE DATA           l   COPY public.owners (owner_id, owner_firstname, owner_lastname, owner_phone, owner_email, image) FROM stdin;
    public               postgres    false    220   �_      �          0    16818    realty 
   TABLE DATA           �   COPY public.realty (realty_id, realty_address, realty_price, realty_type_id, realty_area, realty_rooms, realty_status_id, owner_id, image, url, floor, underground, residential_complex) FROM stdin;
    public               postgres    false    230   �e      �          0    16803    realty_status 
   TABLE DATA           M   COPY public.realty_status (realty_status_id, realty_status_text) FROM stdin;
    public               postgres    false    226   T�      �          0    16811    realty_type 
   TABLE DATA           G   COPY public.realty_type (realty_type_id, realty_type_text) FROM stdin;
    public               postgres    false    228   ��      �           0    0    agents_agent_id_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public.agents_agent_id_seq', 10, true);
          public               postgres    false    221            �           0    0 %   client_requests_client_request_id_seq    SEQUENCE SET     S   SELECT pg_catalog.setval('public.client_requests_client_request_id_seq', 2, true);
          public               postgres    false    233            �           0    0    clients_client_id_seq    SEQUENCE SET     D   SELECT pg_catalog.setval('public.clients_client_id_seq', 20, true);
          public               postgres    false    217            �           0    0    deals_deal_id_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public.deals_deal_id_seq', 5, true);
          public               postgres    false    231            �           0    0    employee_employee_id_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public.employee_employee_id_seq', 1, true);
          public               postgres    false    223            �           0    0    owners_owner_id_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public.owners_owner_id_seq', 53, true);
          public               postgres    false    219            �           0    0    realty_realty_id_seq    SEQUENCE SET     D   SELECT pg_catalog.setval('public.realty_realty_id_seq', 448, true);
          public               postgres    false    229            �           0    0 "   realty_status_realty_status_id_seq    SEQUENCE SET     P   SELECT pg_catalog.setval('public.realty_status_realty_status_id_seq', 3, true);
          public               postgres    false    225            �           0    0    realty_type_realty_type_id_seq    SEQUENCE SET     L   SELECT pg_catalog.setval('public.realty_type_realty_type_id_seq', 2, true);
          public               postgres    false    227                       2606    16782    agents agents_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public.agents
    ADD CONSTRAINT agents_pkey PRIMARY KEY (agent_id);
 <   ALTER TABLE ONLY public.agents DROP CONSTRAINT agents_pkey;
       public                 postgres    false    222                       2606    25734 $   client_requests client_requests_pkey 
   CONSTRAINT     q   ALTER TABLE ONLY public.client_requests
    ADD CONSTRAINT client_requests_pkey PRIMARY KEY (client_request_id);
 N   ALTER TABLE ONLY public.client_requests DROP CONSTRAINT client_requests_pkey;
       public                 postgres    false    234                       2606    16753    clients clients_pkey 
   CONSTRAINT     Y   ALTER TABLE ONLY public.clients
    ADD CONSTRAINT clients_pkey PRIMARY KEY (client_id);
 >   ALTER TABLE ONLY public.clients DROP CONSTRAINT clients_pkey;
       public                 postgres    false    218                       2606    16869    deals deals_pkey 
   CONSTRAINT     S   ALTER TABLE ONLY public.deals
    ADD CONSTRAINT deals_pkey PRIMARY KEY (deal_id);
 :   ALTER TABLE ONLY public.deals DROP CONSTRAINT deals_pkey;
       public                 postgres    false    232            	           2606    16791    employee employee_pkey 
   CONSTRAINT     ]   ALTER TABLE ONLY public.employee
    ADD CONSTRAINT employee_pkey PRIMARY KEY (employee_id);
 @   ALTER TABLE ONLY public.employee DROP CONSTRAINT employee_pkey;
       public                 postgres    false    224                       2606    16767    owners owners_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public.owners
    ADD CONSTRAINT owners_pkey PRIMARY KEY (owner_id);
 <   ALTER TABLE ONLY public.owners DROP CONSTRAINT owners_pkey;
       public                 postgres    false    220                       2606    16825    realty realty_pkey 
   CONSTRAINT     W   ALTER TABLE ONLY public.realty
    ADD CONSTRAINT realty_pkey PRIMARY KEY (realty_id);
 <   ALTER TABLE ONLY public.realty DROP CONSTRAINT realty_pkey;
       public                 postgres    false    230                       2606    16809     realty_status realty_status_pkey 
   CONSTRAINT     l   ALTER TABLE ONLY public.realty_status
    ADD CONSTRAINT realty_status_pkey PRIMARY KEY (realty_status_id);
 J   ALTER TABLE ONLY public.realty_status DROP CONSTRAINT realty_status_pkey;
       public                 postgres    false    226                       2606    16816    realty_type realty_type_pkey 
   CONSTRAINT     f   ALTER TABLE ONLY public.realty_type
    ADD CONSTRAINT realty_type_pkey PRIMARY KEY (realty_type_id);
 F   ALTER TABLE ONLY public.realty_type DROP CONSTRAINT realty_type_pkey;
       public                 postgres    false    228                       2620    16897    deals after_deal_insert    TRIGGER     {   CREATE TRIGGER after_deal_insert AFTER INSERT ON public.deals FOR EACH ROW EXECUTE FUNCTION public.update_realty_status();
 0   DROP TRIGGER after_deal_insert ON public.deals;
       public               postgres    false    232    293                       2620    25760 &   deals after_deal_insert_delete_request    TRIGGER     �   CREATE TRIGGER after_deal_insert_delete_request AFTER INSERT ON public.deals FOR EACH ROW EXECUTE FUNCTION public.delete_client_request_after_deal();
 ?   DROP TRIGGER after_deal_insert_delete_request ON public.deals;
       public               postgres    false    315    232                       2620    25651 %   deals before_deal_insert_update_agent    TRIGGER     �   CREATE TRIGGER before_deal_insert_update_agent BEFORE INSERT ON public.deals FOR EACH ROW EXECUTE FUNCTION public.update_agent_amount();
 >   DROP TRIGGER before_deal_insert_update_agent ON public.deals;
       public               postgres    false    232    294                       2606    25735 .   client_requests client_requests_client_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.client_requests
    ADD CONSTRAINT client_requests_client_id_fkey FOREIGN KEY (client_id) REFERENCES public.clients(client_id);
 X   ALTER TABLE ONLY public.client_requests DROP CONSTRAINT client_requests_client_id_fkey;
       public               postgres    false    234    4867    218                       2606    25740 .   client_requests client_requests_realty_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.client_requests
    ADD CONSTRAINT client_requests_realty_id_fkey FOREIGN KEY (realty_id) REFERENCES public.realty(realty_id);
 X   ALTER TABLE ONLY public.client_requests DROP CONSTRAINT client_requests_realty_id_fkey;
       public               postgres    false    230    234    4879                       2606    16880    deals deals_agent_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.deals
    ADD CONSTRAINT deals_agent_id_fkey FOREIGN KEY (agent_id) REFERENCES public.agents(agent_id);
 C   ALTER TABLE ONLY public.deals DROP CONSTRAINT deals_agent_id_fkey;
       public               postgres    false    232    222    4871                       2606    16875    deals deals_client_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.deals
    ADD CONSTRAINT deals_client_id_fkey FOREIGN KEY (client_id) REFERENCES public.clients(client_id);
 D   ALTER TABLE ONLY public.deals DROP CONSTRAINT deals_client_id_fkey;
       public               postgres    false    232    218    4867                       2606    16870    deals deals_realty_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.deals
    ADD CONSTRAINT deals_realty_id_fkey FOREIGN KEY (realty_id) REFERENCES public.realty(realty_id);
 D   ALTER TABLE ONLY public.deals DROP CONSTRAINT deals_realty_id_fkey;
       public               postgres    false    230    4879    232                       2606    16836    realty realty_owner_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.realty
    ADD CONSTRAINT realty_owner_id_fkey FOREIGN KEY (owner_id) REFERENCES public.owners(owner_id) ON DELETE CASCADE;
 E   ALTER TABLE ONLY public.realty DROP CONSTRAINT realty_owner_id_fkey;
       public               postgres    false    220    230    4869                       2606    16831 #   realty realty_realty_status_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.realty
    ADD CONSTRAINT realty_realty_status_id_fkey FOREIGN KEY (realty_status_id) REFERENCES public.realty_status(realty_status_id);
 M   ALTER TABLE ONLY public.realty DROP CONSTRAINT realty_realty_status_id_fkey;
       public               postgres    false    226    4875    230                       2606    16826 !   realty realty_realty_type_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.realty
    ADD CONSTRAINT realty_realty_type_id_fkey FOREIGN KEY (realty_type_id) REFERENCES public.realty_type(realty_type_id);
 K   ALTER TABLE ONLY public.realty DROP CONSTRAINT realty_realty_type_id_fkey;
       public               postgres    false    228    230    4877            �   �  x�m��n�@�דw�53����A�t�8v�Q�U�U%	�KU����i��7⟋�6�,���\���9È�*iƣX�A/q]}�����+}���%�&IId=��h�z*��C9�*|Y	�sP0N8�xe�`<����vB�9�W�~/&c����?<Յ���Z��?����Z�:wpŹ��r�,�+�I��,hb��<�i�)�I*;��d����������{������N+A#�̌KX�jOu��K�X9��8m�ډ�&�H	MQ���ά���[�M����X	s\���>�����Xi@� �$!�h�~�Ӓ���i��O��]_B�K�X��~ٍ�@N��;�*Xי����1SC*�t��qY����RfD�j0��^�}���w�x,�������=��s�f9�����	'Ű�W��hj����`+L�c,h'~�B�DM��*fr��?�����u�����t�W ưPgm���-U5�w�L�YfxfFGF7������#9U�[=�9��`��d����i}�e��=i�s�Mѯ���)h��h���F;$�M�v�os[<NL`�x�/�5��~��^� x�Ǉ�,��'Uj2��:
�-vf���2�V{'�6��H]��]<�Ӹ�����|b��o�N�90Ha�©����Rb�]U#'�S�D�mn��<��z�z��2      �   8   x�U�� C�s��	k�E�up���|A��Yb��4�~i7~鰠W��$w%y ���      �   ]  x�}�͎�0����X��4΍�bv�%4_JҲ���q[	�@B	q��j��n�&o��NJ�5\�cG��?�0��
.�n�������py�$3�S��#u.�2U����I����Yy6��ª{�-vIϱ�8)USQ�n8>�o(�1b.�Aװ�D<�E"��3դ2��NNK�7��;d�`�-1�>ܮ�V�����TMj5���\��	|�K�vo�t�Sj�,I&�DR������>�-����V���*-��cr�%M�̩]�"��h�5�ik�"�<�*�R�$w��Mh���n�τі��H�5t"A��F�hÐ��r]��51��h�rW��0��+�� b{[(b2+^�Vy=I�Kbs	�Py�@�+��K���m�{�U�2j��k�Y�i�m���о�qX�t�-8�"=[��^�z.M_�e2IrZ+��q��em��~����|�L�<�C��6���3�j��=����x\CG�aL��J5�{Q$�X�z۽AN?��6�m����H���M��r���t����Eh���O��=����F? iI)MU�m�����?����_E����U�D�w�zLG�� �q�      �   O   x�=���0CѳمL��]��mA���Iv�3��Wڿa&DT��4�od՘�ύ�j\�i�8qWͷ���!"/T}{      �   z   x�3�L�I�HO���E���ML8/L������.6^�pa�-8/L
쾰��NKC3�B3sNc�^=�f�Ԋ�܂�T���\NCKK]S]C#N## �P�Д��8�H/� �+F��� 5�0�      �   �  x���ݎ�Vǯ�>�ˀ�� �9��Y
�`��j�I�H��l�JUҴj)w�Ɗ���W8�Qg�@��@��{�?�3�&_���L�)��Mu	��|��0-{丌�1ײy��ɒ����E$��ɜ%��"5�o/�3��_��W��3&_W�'�������c���Z�x�<K��<S�,&���0A�O��Vr��X�-��c�D>ז<�Bt)���(�� >3�|��Vh�	��L��(��q�B[�FL�-���L��?��񫺑N0��(�Z$&bکn�h$MU ��[&�T��O�:� ��� �H�'i�K��x.�o!iW�Ĥ��wJQI�k�b1�yTpm&���R�*������QB�>V�L��� ��a��z�m�#@�S�jy0OfBt(�{��/ �����&��;y+�@�2)����/� D� 8q����б�%�֘�W*ɵUk���1�_�H�Sti�%���a"��^�J��Sq�TD��	�Ԭ��S�<?n���s�MQ?͢�F�ѧ�H��lKtuhr�'QДH�&z	y[Q�	*�m��ˣq�_�󠉮�'7ժf���_���l�Ȑ6K:��x�F?+cn����tTj�bSA�����v�������V0�	�f�d�A����!&�ѻ��Q�T��A�جH�!���
���Ma75j;�u�ϗ��ԯ�ԑ��J�����m��z1�S(w��~���Q�5꫑Ǩ��+����wD��
�s��:�I� ����٬�f�D��$0�*���Y$���?R�7н���[���GH���=�E��9�y��Y�#\
���F�{�NU�A�^�~����=�dsf�<�eC��U���{���Ӣ��G�0��E=�)�5�E�ߡ�K�+5�?�v�g._��Uԟy���5*��>m�Fl���>�i���Ǹ/7�dT����j��0��$��:��]tu����`I^���p�_�غ��,G�F�K��u�i���ǦAU@Z��&�ٚc,����S��f��VO�[
�wx���Z-����(!|@�MWAy�mkp+�9�������|x,�d3���v�mDu��ק�y���R��Nt"���.��`��O�i�H�Hm:�K��.j�m:p#ľ�C�1���_�1�8��O	6�C:��E�)�f!/����P����BYʔ�ɳ<� K�1��/��z,�@��?�ݷ/1��B/n����1��H���X�L�ۻ�n��6��uF���ri���ȶx1	3p��ph�.���A���Iy,�d�*`�S�_�����;���@H!!�����9���y���؎n��XL��6Y�C���G1�Zy���6F[�?�uL[{�c�}�Htt�^�,88Gz��o�^�������v�!�9�E�<�ͣ�~=���ᙖk[��/ǐ�{sܭ�-��Y����o����� �_d      �      x��}K�]�q���_��5Ѩ�cvǄ�1�c<11m`,sL�
��v")�r�#>-* � (ڔ� 6@�/��G���8u�:��I�ajt��GV>��2��w�~z8�z���p	���������p~�������OO��w���燳�����������������s'�.��8��9el�w҄?��^�}�W~�O�Ϗ~���W^������͗������O_��͗o�p��_�p땛�[��w�������z�>�rw�����Ƴ�wO��s��`��W����p�zx�_��?��~���k���W�~�ބ����	W;;�?Ua"�@t��h��V7w>�	���CX5,%-���֋'�����5� -������	���g�k{.[�������G���?����ܜ��O�#���5�^��{p�g$?���'?�c~z���_z�O���N��%��u��7��b�������9�6�C�\���tMp9�K_lA�,a邔�!'�������#Z���[Z|�n�_����$���t�o�®�ƕ��\��}o���5]�S��Ex!�����}��).ܩ`��r��᫮�+&�t [ 𿦏<�Nt)S{nʝ<��:<,n`������aN��b\�Smv
DH����ĵ������Np��K�RX��������d[R_�jeZ����r�޸�혱��X�$m�}��Ilw��_߮�i��L���|M��!����~��~r�7�v|\�H��Þ;1n���Hvjã*�۳�,����2���A�)��(n���Sxv�.|�Mz� ��휘+R�J��|�C�:,�ȇ$���ʰ-���3�O��A���P��w�Jj�!��`�^��$>WX��~ڀw�:H�LR"����p/�{�{����.�(<�G{�+_
�4c`�_5�ӫ�鉂p��4�d�T���*���ê}X���@�]�cX;���D���V��W>�Ð���N��Zιg�Kpޥ.��C/�b/dS���F*�<:%�>�+K��䩋��4��}/�*&��.���K��n���n��/��o�A%>��9�gP��r3��?=�g���ҳ���U$�Nv:E�	�9Ek� u#tS�,�o�>H�/�� uyF~��Y_<��1M����@G2.��Wq,	��?�7�0,�Urhk{a6^�w��'�w���z����U��x0�>)-�	���od�l�F�-,�Xņ�U�3��Nt!�.u��YZ�NMx"�]�.5�|�� Ft�?g��8��o;�h
�]���	��s'�N�I�Y����{��1$��ǁ����7�*��hf���A�`�=3g&��c��k��nat���<��z_+��� ����x�� e2D��\m==�������u�>�:�4�;�eH��	9���[|���u/)}Vyqt�w����r	w�yy�c!Z�K��:����t��B�Z��'���b�1_�&�cv��5E�zluFZ��8��ߐ�u��/���+/�z��ɟ�z�o�5�C8�srp����W��`��AT�
(��gta�"�A�3�I$��1+	R�V�D���k@A����$�(&!*�í|Z*��R�ּ�i�ߞ��KO��u���hH"�U��N]l�tu1�>��w��/ݾ���=��O�-Х���.Dj<�Ν��3�c��o.z?�#�v�������w�rş�>���ćJ�\�����ؠ�|q�z#9���J��ςQ�#v�+5r����ؐU�Y����콴�G�� Z��т��B��]ڇA� bt�&�n�����먦
5�u��e� 0\��}�����M�>,ʷ����prz��3\�-�쳍�2%�!]^����m��#~��at8Б�������|��r��1��3�Hr�i9
����>:^5j�3R����9?����=F�s%�Q���|�����T5���yGԧ����_`��N��������'��fz�n��1�k��3zgu2�$:���-x(ͦ����k��Ł���ާ+" :%6`?�&<1S�6���@X^�!�&��d����$����Jۢ��p*�3J�ѯa˿/d�F��'4+',:��3��@D�n-$�3��\-s��;e�/E�[�t7�ZIi��[Z:oÚZ�3GW���yv��H�2Ԉ�N�LM���	a�.�����5�η��'�o�����#ҍ��Q(E��s}p2�Z(� (����WwQ�=Jn�	�AJ�ou+���5��27;��?�xzn��U�H�	�xō�Ɠ⮃	��R�BqE�ĉ�,��)�,�{O��''�@ �׻����2O��R�Y���^� �2p"��\3(/W.`��e,�R!.×�^�E�^�o���/^�q��P2:�S��SPim�\�)���=%QX������9Ir>������J<6=�w)~q��Ⴀ%�T%����r�&Ƃi2�b;7�ײ��O�_f:�����~�Gl��9ۛ�r�X|���=B����Lb���{��7����f�p���ވp�I~,�{�Z������%�k�! �Q���r �B�jMS�J�v���FԦ#�������
���,��)� ���{fh�M1g�%��I��}�mW��Wt��;� A��*R�����K��V���!GJ���=�S.#i%���K�@6:9�9j�D5��7�~�ڞD�l�W��:A���eqO���#�0���,u���D��1����߃1��-�~$��,�'�:K/ n�A�M������sm�P ��������s$Q7M�~����?|���-���aT�iK�0�� ڰ�fhI�ItVi):���ҍ>cc.�NzR�����8�߅�_@r����:��;㏴��o)��V� Tׄ"�3b�c6��ZƟ�R��Y�O����J$8q�P�[*DÑjQ�1�0��LL�XS����wi�ɭg̸BٙK�uT-��q�1�������9���A���|o���bR��	p�X��!�gC�SNINX]%	llC�)[IZ���!�S(+%oOO4 6����E��
!���|42���c>�Am��zb#pG^oJW&"��|��C��=5ER��]�)���}��99��`���b]d�"��hq���&aAcx�p	l�����$;�L��>
����(���51��@�_���~�ÏR�<�}���$!�&�3P�lg	�-��<����i+����\F0F���\�e"lӞދ��}2K�R߮�\�(�Q<C�S�9�>��	��<ժ1�r �( ��Y@�5�
"i����i�c�����A�p%`F.��'!Y���Q-� ��Y�G���=:��j,"5 ����i�_���j[���y<���m-������ ��;<lX�����f��m�]X�&��$"�CNP�2�K~
w�^��2O�e*��jNK<��m���1�������|��vv�w"�Fs�	�ﭫ�q�8,���Zͽ�T�1D������f�}o}��rK����-��g�/:Kw�^�A�5Bo��A��d��T����Q���O�I�*�����oDǂ�d�?ػ��_re ����WA�����=6�&[%}�ls��'�_�������8U-�4�Ϡ��0�d�֧<���4�� �h�e+�qMw'�ў +|��f�K�T�|{Nw��9.��k�^>����ߣ�E<)�6����* �gJ��6f�i���8_EL���OIk]��J��#	��F�F����AyP5,`E�/ ~���\�#��q�#�u�]r�%L�v
�2��GKU }�LM�j$�Kc���Lb0���qEf#ύz�OB$@�\�r��3W�Km2����Vr5Ç��a��߿t����m��%Ją{:S��S͆�R�IԒ��wU��*����8]��A��_QEʢkK��(Y�<�N���^Y,�j��/�����ۡ�8�    ^�e�A+TF��O_(/��B�є��P��{��NI.��*Ьs�z��̟��t��sf ,^����{_���<И��Y��Ʀ�ϔ������:��q��rׅ|��?}���/��ON���W~r\�T��@'�h	�=r�����>�I]�Ym'�ფ�Þ�o�uF��˜��~cV1��&a�B!�l��ë:i,כ��	Ʉ �L*��TNNXo��_]XV���y<����ü�"�����Yn�d '�d�K-X��V��O��Y]���_ܾ�������,U����]��F�f=E�~~��*�k]�Q�ѓ����L��[��L�����ձT�6���V��}n����wUF�!������;H2F��P�����d����wH�������[ɒ#�$պ`�Y��W��^�z%��<�E��E8[� /��"�R�Y�9I���	
��TMVT�~I�ܓ�q���ɱ�7{�"���{�-c<{���D,2�M��a��:`R}�Y�;E?�ѫ�Uc��S0K�&�
T��68��ؽo�,(��O�~Fq,,rVAhB�w��E��e��x[o��A�*y=�;qGU����+fIɻ6�=�l�fG_��S�+��y-:��	{��%�NfHyÕ�:��c��v���@�z'ٵ/��"?��Rw;D���6$�T�g��Д3e�Y-2�SL83mu�%}�1vK(�p��n'd� ���	���潳�p�	!��2?*d]�NZ�v�F�y
+�͐>�w�����baf9s]��促B��T��u���
�/2+P����)ǒ����5!C;+�7	�)�NtW3�,Gu_�c��!������s��~Bl�������RR�=��I˵ҝ�-ͼҞ|��@���������{�{����O^���X��� "��R�X�@bV�9�2Y��?M/�/9�����^`�ɧs���W�Z:u�Z����5Gr,e]r�J���Z�}���Տ]�(���'�v8���6�t����q�Vg7 Q�@w�	�s�����/B�Q�>ɒ��!X}$u:ʖ8!��� �����k�^�(X~7������_>wb����l�`
���GM����Av�3��G��U���Oa����۔]�j�cRe�ha�d((���ݍ'���1�ΏY�f5؝i�8�7۫q:;S�*� ���;W�*��\��t�4�!�UYҹjˁ���U
�l���(?�Ýx��,Nh�Gp�x�=�@��,�f\3q2�+2��J���₷�[l�	��Wd�,(��;k���$��9N��Z��{ؾs8:����@�ʢf,�А|��5B�3��άJ���P~Ei��C]L�P;�5|йQ͐Z� �YI����uS��c����ZPx�?���p�����ډ@�!���>�H�[��4�2�iD2�|(�#��MkQO�0��:�<�A��`�<��p�Q%6X�}r�����n��.V�����;;SI*�N%8C4¾=}:�MGl����T)y�p�!�"������e��l�:kias�vg�ɂ�B~v�[��]= �$�2\�ةYUJ�'����^���"%��G'�b8�}gj���dTHFj�8NH�A�D `�;�^-����'����lԧ��N���R pR��7.7�����u��xO�އy)s<$�1ٕ�����#E�����5�.�����E��וn�D���S�y-�8������-��,J�I�wm��irJ&������4Ѧ�V��Mߍ�O!���w���[��3B9�����~��i�j܋J�il�ꬲr�G��D0��5�V�k��m��0}_�G�:���u�z�{Y�FH&�i/0�����?ͯ��0E���d	������Xo�i���ɕ�@qg�;� ���`��ű�2�W���\��q�����Wۡ	�0�4�C'4��s�6�3г�Ȝ8�%l�fZ�%���ޮ�R�S2�]��Cן������K2!m��:A�f8�J8S��v�6�	
L��(G��Zl@sB�eo�C��4�Qm4�{s翓�*����q��~z���d�p��99��Q�bG�8�7��w�����_��[/YӁ�	���̀jA�b�!6;��fG<���JJ-Yd�p�G$,�Է��e����P�l���i�*�:�洍|���s�,]� �f���YPӍYħ��>�b���oVJ(���%��/O�!���?�z޽�h�|W�)熰ef���M�Dmv�[�^(���]!M"�=����C�M=��Ixrq�,>�;�K'�#�:��0��V�	n�������[��X�<���=��M� V:1�Z�o{��� �(G�B��"r�����E15�no��/�2U�)C��vNZo�v�NT��p�,7+�fZ��M"u+e�.G�'���_�׻������
c�/��h�Ĭ\!b����n����b�ꢸ�FA/��%�B{�.bu�,S��hx��o�b���Q2e��hb����Q�(Dy�ᵘ���tZ1��6�Bo�B��w�ճ�o���,��9zp�hԳd�1�T-����f=�B�!)�Xo���"=�[��Rd7O(�)"]f�@#w�]CFzle+����a�y�i4͊M�]�bRq����[L܀�<�~�9���Q����Ӑ0V�yM腿"&�S���(r�|�����Z���� $���SE?��;�rA9�2q�������0,b���U��.���"��� 1a\+��7����*��f)�fI;&Y�2�}xŃ]ȳ�FfQ�΍l���B����;R&��Tq�>԰��
�5_�����Ʀi�R�R�����1�l��J۩���Z����:���[�ֵ�B�ͨ�rf���	�.D�Bs5�tez;Uߗ� �Teɐg'��;�
l�
�����i{;t��h��h�Ĳ�pJ	�MԹ�w� uR��Wf����\��w;u��##��["֚�]��R�h�ΰ��4=������NI�Χ�=&"�:�s˺=���iX�� �W��x�� a�eX��HG!l��&T����4[!ܡ�KO	����!G�.^��m��qk��^'�h�t�n�SQ�:Ů�3��&:B�thk�)!;S�B����V����P����;]3̼��t�_�@��(��˒��K�b��&-��|�wE���Y���+��Rd�8=�_��Vo椏�\eJ�"�R!gx"��=�BΤW�N��jKP�-��Zt'�+����7�de�B&���L�s�?��v�\��g�\uzwL'Kr�e�V��~W�����-�e�+���f�M��؍-8���Che0�c�Y���~*K��#�r�l�[t�k���*��BZ���d����}
%�`:��^E����wiÆQ]ac<K(XF8V2�������|%�ڌ��Ī��{	�e��d��m����zZ���j�= +��4}lr�z�͝�~t�:,X�a=�a��,��������OL�N�'S��]�����a/?<L���I]wt+�X�gSE�U�ȱo�w8m^tP���� T �����;�vi��.�]8S���~�g@}�G+c��᯹�f[��>��d��ܷ�/����͛]���i�Ww�>��Y��B�G,��0ǩag<>�WaBf�[9��X�>fJ�����wD�b��%��|���Kۉ������%cj�"R�E��N�HkG}�E�؋�Y��(z̥�fU�9��ա�JL�V8�備�`GBxz���O������5y�T \S��1�T  �EXH���ۃ��C$ȒS+�y8+�j�fA
xR(r7�I�^o	Em�,�d
�������/T��+g������2�Nz�����/�>u4�{���I:Yx�s��F������'좏ٵ����v���H,O�wN_~���)+NOfh`-��~,M���.�+�7��y�F�^ �V��ӝ�ҁ��ִ~�M2K��4�1�"{�"jgt%���V>!k    ��47C,�I��^��DmNΒ+}�L%�J���5�pt���l$�ms֫�>��?�N�4Z툅Ύp���n�K���Z#�@wl�<�K���f�3mJ2�0�_�(|�>��L�||�JY畀��v�Dl�zx����s���d����@ �T�u����as�G/�Cv*��Fl����A"��^�f��v�Oa�K�0lR���=Apc-�m>3�/۫9�̕j�.�^�g*,�II~�P�l��DgK�m�BP�H�Flq�K�G�����w�5ʹ5X��J|k���j�K!�|�)�c�(GM�>���`K
'�:b�9[/��Q��s�c,}D�瞢D���|��bk��Ք��v�u��1��[ڈ4���-Ӡ��,�m�q��;�	8��:��/���.C���rd՗4�
[���,"AQ��]��X�a�N���t�ύ�s�},�8�*x�_��]C��f�z@F�l�f�JG�����l.V�l�����
È*%ʇ�U>Ҝp��O))�B����`�{�8���$2�%Y�f�F�dԴ�DL7ғ�X��	��1T�*� t���8��&���Tm�8jSS�w7��on4��@���(M�ȹs�{��*�6���`g�7�4C��WZ���^`�se�P�v._4��~�����'���:Xe��ǐ�M��]�nںE	:���Gvu��LϽ��[(��+�:���n���[����뺗�h��N��3�p�Ľ����H���_�g7��uь�u��{�%�;�=m��;�;�F�8Q��*3��̦��:~'(�,�|��&&c��;��8O��f�f���L��%��3a��N�G�
Ѥ����y�L�1e�B�^���qH݇OB�$$6�rKD3ȫ|�&����:4�*h]��pR	��m?��_G��%P�6�egNELS��r�G0�Pv^�΅lu?[|u�R^~����,cҧ,�h_	Wtd�ɫ�oe�TrS�@6x��&R=�l���uBS{�N*�� Th�K�EuH�?��h9ϊlIv�V�#���(��VQ����RGn[�
���G�|Z��e�;*1�~�l����:"�oR�T� YI���{92p鞩!���z���M���Q�e�g�K�@V��l.Ǵ�#;�*L ͷr4�sVRP���T��X����Q
�J�վZ�N��/R���X�?D��.,^��W��-eu��@5˱�H�0��Ϊ/��9f0���XW�$�}��Z���r�DqWGaR9�t�]��-��K!"�rֶw/��(,�=83J��`d3=�C�[2�K�BG���̼�=�
Q�~�'j	S��)�6�����R׳��L8�კ*�^��D*�~0c]�^W���1�M���C�D��8f�HcA�i���LPe#q��p��+�_ ��n%]%G$nj���X�	�@�t7�I��9��c�&��j���R�D�2T3)��xK/�lB�(l�Ysfk9ml��8����b
r	��1��נ�O�k���TT�hr�p�ׄ)���.��ug��'&P�@s�|���G���`���Pz�'�˹�5"�Á�522���櫫A
W�G��a�,�����T�^���\����e�#��J�w�E�E��3+T��2)��q�����ï�!z��̝K����%�:�
|�۵o�\h>ȋ$�I�욓0[��҉���ͮ('����Y%��H����1�R6��Xi37����X�Dj��;c��J��q��q�P�:pn"�\>
���\[���a��)d��|KX���G�s,UL-[�a�}ю� צ��:����dcj<���\`Gd�N=J��kkU�	��� ?�?�R�r�t�<�F�L���
;��Y\�rGa����Q߿5Uk"��J%]��.$��z��-�1�o����2� ��H@�,ʏ:[;0���Í�΅ŵ-O���U�����!��z+��8�>�`�eb��<�4��$�c�@�ϕ�����+L�_ߟ�s��Niu1���W+�#7{hv )|q�x�R1�ϥ1 ���R�����9�K�B\��|�r�0Mzc_:����K���z����,���c�o�T�/�/ϒ�XЕ�f:5+p�b&ڠ:L���(Y�t��LY�jH�rNը�<�cCT���.#�Xƹ��R蜻ъ��뵖�*���v�'�'�ʲ������XL���Nx�l�j�fx���ƝŚ-�ޡ9Jk��lnT\�0�	�u�;�y�NeB��\��AoaӴ�%�b��q�4�&�('��F[�b�Lzln7z�2���������,��$y��b]�{�<[�K�Z��ܺ�$̆���T�`�/Յ]���G�`<
���q-��ގZ���L��0�1ҹ���<h3��2�Lz�ߍ*'�����+���8ոЎ#Μ�+�*d&�D.�KW��+7Z8���aSG���}���DUn��֋�H.���1��G�ۈag��-'z��4i΍�A�f�4Vb�:��c�f�\��"Y��03�6�u�
�j{_�9��^vTd�)����|>}���}N�����c��PTS�ݯ�f��99�_�o/��	�#ʬE��L*˿ƫ�82MM�?��ݸa�j�ލ�:.�n쥖���ɀ�S%M�u�6?�<�2�"���y�\����t�0k
)�Aά;�w���?=r'i�s��2_��Жb�B3m�_}�v��y���!�N��"�XN�,������@���Y*-�+���FlǋaC��}���=�R
��W��Z��\��9W�k�5�Ï�ac:!�k�lU�����Oq&�J�j�fP�5B��V�Ù��b����ҏ}�q�D{=�\�s|@���Cj&��z�z��6>�tb�&e��ի�/E����Sp�Q4�=
�%��Q��'�v댓��_>���9#���^��l�Q��q�y\���"%i���B�1s�!�v���� V�}��D�L$x���f�	oל7'k�F�*EFE��x-u�ͻ�19�Fo�/;*���r*�����ؖ�}Zҡ9�B��5Gg�߂sЗ̉����C6ɪ�D��]6��\]/d�l-�8cC�����Pk��/@9�t�� �RJ��εP���ܛp^��GQ���+	��
4�Q���ܦ�.s�͋��O�պ�Yr�X�T�zy�Ly��~��}5��������X'�ʝ�^�|ɔ�ӕ�t� Q��{ğ���t���=>�٩c�8��E�Y�֞��qY?N,������.�Ȟ\Y�[E�n��Q�>N6���ƮaG�j�,ڞop�9^��%�jJ��TUۨ��N���� >YSJV�BG��=��_ǓR�}c(W@@���U���#��B��.��L|��9�o�I�r`����(�}*d^�����|��ׇ^����Λ�KJ�B?��-���c���kv	��:~��a��0[��Y�qPv�˨�4�0R����4^��2�kf��w�RN�~?J&���MqJzT&F�i��F��G����;aLzr�(�1BY�F������D^����r�Г�})8�K�-�%~}��L��K�
gR��/L1eM�SJ�f�
�c"�<&�9(���#I1)�hth5v��w�Ô��9���;��/S��Rc�5j����vle�-6�	�e.uJv� קj�Nt'u@���%�������i������!�㢚���B,�4�yi{�f�Ȧ�N�+���>�1^w�2�֏@	�X�X;���a��n�O�P&(^�Ja�2I���.��sL:=[�xI=��JL+�T�����Pe������0Z��9GFk�Zq}�]Hw��'KѰ��Yx0��5*��V~͍���ko4e��p�0�X��xx $l�J�d���.R�QC�,*噤\���"C>�♙���e�b?T��I��i���5�Y�\'��P����d�h�U�\�8	��n���1��YO�8' ���(9��A$(�d��.0�/���`�X�uS7w:ψ���r�h�$݀�i��&N�uO���	�����H2*�~�
m�V6m7�'� �  �>�B��vV�j�K'�T�8[�Y����0<���2^%��ܘc����\g4�tBV!����jsa�f��Ճbk*��j���@|��$�	k��6D;��&����!L+*P�k��I����W'�y�I��VA1U������I�<�#��؊���%�N���,�ʱQ�E�g�����.S���q]E�a�ך�im;�,�A{��<)��̃t��*$��Uw��^p��:�	�a�~Y+e��c��c~�Au8l�p���� �U{�_�Zeˬ[=;�6rZ#5�f���xښ�k�8]��H��}�롾�u�+|��F]v��:ny�0t8� gI�*�3���4���+(��(k�8��:!���>� ��T��NNw��o�@�G���a�_�Gq�'k�ts~�H�%�k$���q��-�j�ZS5��a�s�U�˵�Z�O�M��Zx��dJ�j�׫��8[��5�N���ms�<{Ph��'�b�n`�1�i�+W�Zt��c���{�g�U5|�\�0�J��HjR&�;������Ieav�J�q�[	�M>�ZTaR�ͱJ֣)f��z��E�zؔ���h���r����+A�ٵS��S
��H�����/w�Q[�@�~��SN8�ڏ�lTľ�<Ol�Q�:�+֍ZX��
GY�V0'K-0'�����c�Xxb����R��v-rhJD�n��:�O��0p>B#O�t*��L9�s�f�����&��}2�{.�r�%.��f�.jI����[W3���8[�����X{��fn�|9���Fi�]S�{��S�j�D�-9 �[v�X��^��6�Cٍ8��X��͊�WMԪ��Ĺ��bΙ�h�-�>~�\���s���g�\���6�u���0��QO�����gF��|�|�F#�emC(�T�2�d��a\f�gz��,����8��x<��m��~�69������ӴՊ��쟣{�����h
��m�z�jYF��ᒐ�G�c���ϝ����Е�����[ASw��Pj9���1{��z:\����ˆ�!�B�������wj�>J�)��ŬЛ���c���:�{�j������6�8������	�Wlx�G�-���o���@�?����.�Ѣr[�vdX��*Jƪ�����M��x�����(���ˎʜ	�bæ�u��vN�6���p�ER\�B	� ;0yv3\q}�o�a}v�Re����zPdeg��u���|�����\��ՎZ�4B_Ӛ,���[r�'��?��y*b��r�-���c���yA���V�q��g��F+>
��#�N���a.3�jB����-P��N�6��ϯޅo((7��X�jw�x��LL0ͭk��~�طR�|��!�9fz��6QcX?�;��L�CPϻ���H���E!�>�m��Ek�s��·b���C�V� ��I�Z!�uB@?ҍ(ڼ6݉¶���%�bz��\�t�V[u�����)��Q]5L�g8�ו��'�S��L�D���:_zedǱd�Q΍�N~=�l�<4��j�6Z-y�Ȕ���M������F��c#�Nq�ߩ���}�ȴ�p� ̯�*L�[�KfpB�O�_��>�ڇc�G��\�-�g��-�ib�	�ctnA�aDImb�ڶ~�E����@����)U;�ޗp�@`��b����\\7})T+�L��n��=�r(	�}G-;C C!��W������������l�T�u�a\��zDTͺCu�:c�A�v[VLw:�G��Y���F�����-�[���X�-�j�lK0�j�c�'�E1�X(I���� ZU�6���V�8�E��J�qb��z�C7kR��}��5�&3"�
�7�e�`�b�#śB�*�{Wix!�;�jx?����G~ƥ����3���lc��o�j����$��kUe��32#8������]��Ш���*��	�t-)��X�ɳ<'L�]#�Ue?�U�K��^=�<A��3�k-�̮�'��w��m3�{_����Yں�^,-#��/���n�݈Z��A���Ҷ��,N�+/d;�����8}y����.ό�k����A���l��MW�H=0l
�W×�[\�T�v�=n��k¾MY:�(%5\�ﰟ]���N�Ɗ�bO�t��.�'#RJ�Nzix^�X�Y6�}	�5{�7�y-�c�*�g���U>0w�٘�4+@�w�E����j�[�x,%�o���C��4o%�lM���D���eUNm*���5�+�%��5��Z[�?��.`C�W���v~raǥ�NMrt�$Z���&��\b��k�.6�y.���b��5ۣn�
�DPb�u��&v��̬"'!��~-��F�\|^��.��~��$4���p�����%\�r�R�+���;ؚ�Y��(�|��rq�ي\o���uI�F��5�`��5���}���^S�}ؘ�9�2��|Ed����H����F��8v�[q(�Z쳀@� ��%�!�ٮ�ĭ�����r�N���Ƶ0��#/��~G�	���V�u�X����Hm(�J��x�0�6%F�Np�y���Qn�	��a+l��]�C]汧��QM�o�x,4�@�&�}$�U��z�l8\t���6�g������Z�G�H�B+�߿�vB�^b>v�A �-r���k�Ϋ-�TA��S��Zm�Qk7� �u������ٞ�����3f\U���>�pk��$��A�mJ��b�����r�/�C�5�A��x���E��
�O��^9��3̹IZWˁ�l1����\�+�f�F��9DN���g���<ז7��z�����#Dl��Ѓ$:�չJ�����q�ެa,�Tj�:6�W���ݺS�Aԩ@�HŸ	?����	
������/�������9N������W��}�[>�c���D�;�O5=�<E}#G=#@�����4t;|/�f�w��iȦ>�v2o�W.bJ��q`��p���S�;�/�b�a;.�[&�p������*!�ƹ�zv�``T�"��7r�q��R���������7�E�6�t�På5�X��R��X������('�q�q}�n� .�z�T�g43����7 ����
8���*P �>6R�ih8g�##�2�}�?z��?�~	ԉo��*@s��)����əX����n�����5Z���&Nr>}�K���f���D��v�$#ބ�k�����G.����������      �   C   x�3�0�b��v\l���e�yaᅽ��c��/6\�wa˅�^ا�$wa��\1z\\\ \�"�      �   ,   x�! ��1	Квартира
2	Дом
\.


F%     