--
-- PostgreSQL database dump
--

-- Dumped from database version 13.1
-- Dumped by pg_dump version 13.0

-- Started on 2021-01-10 14:12:50

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 201 (class 1259 OID 16404)
-- Name: atable_test; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.atable_test (
    column_test text
);


ALTER TABLE public.atable_test OWNER TO postgres;

--
-- TOC entry 209 (class 1259 OID 24711)
-- Name: battle_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.battle_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 99999999
    CACHE 1;


ALTER TABLE public.battle_seq OWNER TO postgres;

--
-- TOC entry 208 (class 1259 OID 24692)
-- Name: battlelog; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.battlelog (
    battle_id integer DEFAULT nextval('public.battle_seq'::regclass) NOT NULL,
    playerone text DEFAULT 5,
    playertwo text,
    isbattlefinished boolean DEFAULT false NOT NULL,
    log text DEFAULT ' '::text NOT NULL
);


ALTER TABLE public.battlelog OWNER TO postgres;

--
-- TOC entry 203 (class 1259 OID 16414)
-- Name: cards; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.cards (
    card_id integer NOT NULL,
    cardtype integer NOT NULL,
    elementtype integer NOT NULL,
    carddamage integer NOT NULL,
    cardname text NOT NULL,
    cardproperty integer
);


ALTER TABLE public.cards OWNER TO postgres;

--
-- TOC entry 202 (class 1259 OID 16412)
-- Name: cards_card_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.cards_card_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.cards_card_id_seq OWNER TO postgres;

--
-- TOC entry 3069 (class 0 OID 0)
-- Dependencies: 202
-- Name: cards_card_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.cards_card_id_seq OWNED BY public.cards.card_id;


--
-- TOC entry 204 (class 1259 OID 16448)
-- Name: friends; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.friends (
    username text NOT NULL,
    friends text[]
);


ALTER TABLE public.friends OWNER TO postgres;

--
-- TOC entry 207 (class 1259 OID 16566)
-- Name: shop; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.shop (
    pack_id integer NOT NULL,
    card_id integer NOT NULL,
    cost integer NOT NULL
);


ALTER TABLE public.shop OWNER TO postgres;

--
-- TOC entry 205 (class 1259 OID 16521)
-- Name: stack; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.stack (
    username text NOT NULL,
    card_id integer NOT NULL,
    isindeck boolean DEFAULT false NOT NULL,
    islocked boolean DEFAULT false NOT NULL
);


ALTER TABLE public.stack OWNER TO postgres;

--
-- TOC entry 206 (class 1259 OID 16553)
-- Name: trade; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.trade (
    username text NOT NULL,
    wanted_id integer NOT NULL,
    give_id integer NOT NULL
);


ALTER TABLE public.trade OWNER TO postgres;

--
-- TOC entry 200 (class 1259 OID 16395)
-- Name: user; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."user" (
    username text NOT NULL,
    pwd text NOT NULL,
    online boolean DEFAULT false NOT NULL,
    coins integer DEFAULT 20 NOT NULL,
    score integer DEFAULT 100 NOT NULL,
    wins integer DEFAULT 0 NOT NULL,
    lose integer DEFAULT 0 NOT NULL,
    spendcoins integer DEFAULT 0 NOT NULL,
    gainedcoins integer DEFAULT 0 NOT NULL,
    token integer DEFAULT 0 NOT NULL
);


ALTER TABLE public."user" OWNER TO postgres;

--
-- TOC entry 2895 (class 2604 OID 16417)
-- Name: cards card_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.cards ALTER COLUMN card_id SET DEFAULT nextval('public.cards_card_id_seq'::regclass);


--
-- TOC entry 3055 (class 0 OID 16404)
-- Dependencies: 201
-- Data for Name: atable_test; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.atable_test (column_test) VALUES ('Hallo');
INSERT INTO public.atable_test (column_test) VALUES ('Hallo2');
INSERT INTO public.atable_test (column_test) VALUES ('Ich bin ein neuer Error');
INSERT INTO public.atable_test (column_test) VALUES ('Ich bin ein neuer Error');
INSERT INTO public.atable_test (column_test) VALUES ('ICh bin eine Biene!');
INSERT INTO public.atable_test (column_test) VALUES ('ICh bin eine Biene!');
INSERT INTO public.atable_test (column_test) VALUES ('ICh bin eine Biene2!');
INSERT INTO public.atable_test (column_test) VALUES ('ICh bin eine Biene2!');
INSERT INTO public.atable_test (column_test) VALUES ('ICh bin eine Biene2!');
INSERT INTO public.atable_test (column_test) VALUES ('ICh bin eine Biene2!');


--
-- TOC entry 3062 (class 0 OID 24692)
-- Dependencies: 208
-- Data for Name: battlelog; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.battlelog (battle_id, playerone, playertwo, isbattlefinished, log) VALUES (18, 'banane', 'kienboec', true, '-------------Runde 1-------------
	banane has won 0 Runden and has 4 Cards
	kienboec has won 0 Runden and has 4 Cards

banane spielt: 
	einen Feuer Knight mit 190 Base Damage Punkten 
	No Effects
	No Dodge!

kienboec spielt: 
	einen Wasser Knight mit 100 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
banane has won this Round with 190

-------------Runde 2-------------
	banane has won 1 Runden and has 5 Cards
	kienboec has won 0 Runden and has 3 Cards

banane spielt: 
	einen Wasser Knight mit 190 Base Damage Punkten 
	No Effects
	No Dodge!

kienboec spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
banane has won this Round with 190

-------------Runde 3-------------
	banane has won 2 Runden and has 6 Cards
	kienboec has won 0 Runden and has 2 Cards

banane spielt: 
	einen Wasser Knight mit 190 Base Damage Punkten 
	No Effects
	No Dodge!

kienboec spielt: 
	einen Normalen Drachen mit 160 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
banane has won this Round with 190

-------------Runde 4-------------
	banane has won 3 Runden and has 7 Cards
	kienboec has won 0 Runden and has 1 Cards

banane spielt: 
	einen Wasser Knight mit 190 Base Damage Punkten 
	No Effects
	No Dodge!

kienboec spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
banane has won this Round with 190


##################################
banane hat Gewonnen!
kienboec hat verloren :0');
INSERT INTO public.battlelog (battle_id, playerone, playertwo, isbattlefinished, log) VALUES (1, 'test', 'fest', true, '-------------Runde 1-------------
	test has won 0 Runden and has 2 Cards
	fest has won 0 Runden and has 3 Cards

test spielt: 
	einen Normalen Goblin mit 120 Base Damage Punkten 
	No Effects
	No Dodge!

fest spielt: 
	einen Wasser Wizard mit 180 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
fest has won this Round with 180

-------------Runde 2-------------
	test has won 0 Runden and has 1 Cards
	fest has won 1 Runden and has 4 Cards

test spielt: 
	einen Feuer Zauber mit 100 Base Damage Punkten 
	No Effects
	No Dodge!

fest spielt: 
	einen Wasser Wizard mit 180 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
fest has won this Round with 180
##################################
fest hat Gewonnen!
test hat verloren :0');
INSERT INTO public.battlelog (battle_id, playerone, playertwo, isbattlefinished, log) VALUES (11, 'kienboec', 'raphie', true, '-------------Runde 1-------------
	kienboec has won 0 Runden and has 4 Cards
	raphie has won 0 Runden and has 4 Cards

kienboec spielt: 
	einen Wasser Knight mit 100 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Normalen Zauber mit 100 Base Damage Punkten 
	Normal -> Water => EFFECT Damage*2=200
	No Dodge!
_______________________________________
kienboec and raphie has the same Damage points [TIE]

-------------Runde 2-------------
	kienboec has won 0 Runden and has 4 Cards
	raphie has won 0 Runden and has 4 Cards

kienboec spielt: 
	einen Wasser Knight mit 100 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Wasser Zauber mit 100 Base Damage Punkten 
	Knight Drawned in Water Spell => Dead
	No Dodge!
_______________________________________
kienboec and raphie has the same Damage points [TIE]

-------------Runde 3-------------
	kienboec has won 0 Runden and has 4 Cards
	raphie has won 0 Runden and has 4 Cards

kienboec spielt: 
	einen Wasser Knight mit 100 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Normalen Zauber mit 100 Base Damage Punkten 
	Normal -> Water => EFFECT Damage*2=200
	No Dodge!
_______________________________________
kienboec and raphie has the same Damage points [TIE]

-------------Runde 4-------------
	kienboec has won 0 Runden and has 4 Cards
	raphie has won 0 Runden and has 4 Cards

kienboec spielt: 
	einen Wasser Knight mit 100 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Normalen Zauber mit 180 Base Damage Punkten 
	Normal -> Water => EFFECT Damage*2=360
	No Dodge!
_______________________________________
raphie has won this Round with 180

-------------Runde 5-------------
	kienboec has won 0 Runden and has 3 Cards
	raphie has won 1 Runden and has 5 Cards

kienboec spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Wasser Zauber mit 100 Base Damage Punkten 
	Water -> Fire => EFFECT Damage*2=200
	No Dodge!
_______________________________________
kienboec has won this Round with 130

-------------Runde 6-------------
	kienboec has won 1 Runden and has 4 Cards
	raphie has won 1 Runden and has 4 Cards

kienboec spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Normalen Zauber mit 180 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
raphie has won this Round with 180

-------------Runde 7-------------
	kienboec has won 1 Runden and has 3 Cards
	raphie has won 2 Runden and has 5 Cards

kienboec spielt: 
	einen Normalen Drachen mit 160 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Normalen Zauber mit 190 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
raphie has won this Round with 190

-------------Runde 8-------------
	kienboec has won 1 Runden and has 2 Cards
	raphie has won 3 Runden and has 6 Cards

kienboec spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
kienboec and raphie has the same Damage points [TIE]

-------------Runde 9-------------
	kienboec has won 1 Runden and has 2 Cards
	raphie has won 3 Runden and has 6 Cards

kienboec spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Normalen Zauber mit 100 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
kienboec has won this Round with 130

-------------Runde 10-------------
	kienboec has won 2 Runden and has 3 Cards
	raphie has won 3 Runden and has 5 Cards

kienboec spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Normalen Zauber mit 190 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
raphie has won this Round with 190

-------------Runde 11-------------
	kienboec has won 2 Runden and has 2 Cards
	raphie has won 4 Runden and has 6 Cards

kienboec spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Normalen Zauber mit 100 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
kienboec has won this Round with 130

-------------Runde 12-------------
	kienboec has won 3 Runden and has 3 Cards
	raphie has won 4 Runden and has 5 Cards

kienboec spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Normalen Zauber mit 100 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
kienboec has won this Round with 130

-------------Runde 13-------------
	kienboec has won 4 Runden and has 4 Cards
	raphie has won 4 Runden and has 4 Cards

kienboec spielt: 
	einen Normalen Zauber mit 100 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Normalen Zauber mit 180 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
raphie has won this Round with 180

-------------Runde 14-------------
	kienboec has won 4 Runden and has 3 Cards
	raphie has won 5 Runden and has 5 Cards

kienboec spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Normalen Zauber mit 180 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
raphie has won this Round with 180

-------------Runde 15-------------
	kienboec has won 4 Runden and has 2 Cards
	raphie has won 6 Runden and has 6 Cards

kienboec spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Normalen Zauber mit 100 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
kienboec has won this Round with 130

-------------Runde 16-------------
	kienboec has won 5 Runden and has 3 Cards
	raphie has won 6 Runden and has 5 Cards

kienboec spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Normalen Zauber mit 100 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
kienboec has won this Round with 130

-------------Runde 17-------------
	kienboec has won 6 Runden and has 4 Cards
	raphie has won 6 Runden and has 4 Cards

kienboec spielt: 
	einen Normalen Zauber mit 100 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Normalen Zauber mit 180 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
raphie has won this Round with 180

-------------Runde 18-------------
	kienboec has won 6 Runden and has 3 Cards
	raphie has won 7 Runden and has 5 Cards

kienboec spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Normalen Zauber mit 190 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
raphie has won this Round with 190

-------------Runde 19-------------
	kienboec has won 6 Runden and has 2 Cards
	raphie has won 8 Runden and has 6 Cards

kienboec spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Normalen Zauber mit 100 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
kienboec has won this Round with 130

-------------Runde 20-------------
	kienboec has won 7 Runden and has 3 Cards
	raphie has won 8 Runden and has 5 Cards

kienboec spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Normalen Zauber mit 100 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
kienboec has won this Round with 130

-------------Runde 21-------------
	kienboec has won 8 Runden and has 4 Cards
	raphie has won 8 Runden and has 4 Cards

kienboec spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Normalen Zauber mit 100 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
kienboec has won this Round with 130

-------------Runde 22-------------
	kienboec has won 9 Runden and has 5 Cards
	raphie has won 8 Runden and has 3 Cards

kienboec spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Normalen Zauber mit 100 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
kienboec has won this Round with 130

-------------Runde 23-------------
	kienboec has won 10 Runden and has 6 Cards
	raphie has won 8 Runden and has 2 Cards

kienboec spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Normalen Zauber mit 100 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
kienboec has won this Round with 130

-------------Runde 24-------------
	kienboec has won 11 Runden and has 7 Cards
	raphie has won 8 Runden and has 1 Cards

kienboec spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Normalen Zauber mit 100 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
kienboec has won this Round with 130
##################################
kienboec hat Gewonnen!
raphie hat verloren :0');
INSERT INTO public.battlelog (battle_id, playerone, playertwo, isbattlefinished, log) VALUES (3, 'test', 'fest', true, '-------------Runde 1-------------
	test has won 0 Runden and has 2 Cards
	fest has won 0 Runden and has 3 Cards

test spielt: 
	einen Normalen Goblin mit 120 Base Damage Punkten 
	No Effects
	No Dodge!

fest spielt: 
	einen Normalen Goblin mit 180 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
fest has won this Round with 180

-------------Runde 2-------------
	test has won 0 Runden and has 1 Cards
	fest has won 1 Runden and has 4 Cards

test spielt: 
	einen Feuer Zauber mit 100 Base Damage Punkten 
	Fire -> Normal => EFFECT Damage*2=200
	No Dodge!

fest spielt: 
	einen Normalen Goblin mit 180 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
fest has won this Round with 180
##################################
fest hat Gewonnen!
test hat verloren :0');
INSERT INTO public.battlelog (battle_id, playerone, playertwo, isbattlefinished, log) VALUES (5, 'test', 'fest', true, '-------------Runde 1-------------
	test has won 0 Runden and has 2 Cards
	fest has won 0 Runden and has 3 Cards

test spielt: 
	einen Normalen Goblin mit 120 Base Damage Punkten 
	No Effects
	No Dodge!

fest spielt: 
	einen Normalen Goblin mit 180 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
fest has won this Round with 180

-------------Runde 2-------------
	test has won 0 Runden and has 1 Cards
	fest has won 1 Runden and has 4 Cards

test spielt: 
	einen Feuer Zauber mit 100 Base Damage Punkten 
	No Effects
	No Dodge!

fest spielt: 
	einen Wasser Wizard mit 180 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
fest has won this Round with 180
##################################
fest hat Gewonnen!
test hat verloren :0');
INSERT INTO public.battlelog (battle_id, playerone, playertwo, isbattlefinished, log) VALUES (14, 'raphie', 'banane', true, '-------------Runde 1-------------
	raphie has won 0 Runden and has 4 Cards
	banane has won 0 Runden and has 4 Cards

raphie spielt: 
	einen Normalen Zauber mit 100 Base Damage Punkten 
	No Effects
	No Dodge!

banane spielt: 
	einen Feuer Knight mit 190 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
banane has won this Round with 190

-------------Runde 2-------------
	raphie has won 0 Runden and has 3 Cards
	banane has won 1 Runden and has 5 Cards

raphie spielt: 
	einen Wasser Zauber mit 100 Base Damage Punkten 
	Knight Drawned in Water Spell => Dead
	No Dodge!

banane spielt: 
	einen Feuer Knight mit 190 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
banane has won this Round with 190

-------------Runde 3-------------
	raphie has won 0 Runden and has 2 Cards
	banane has won 2 Runden and has 6 Cards

raphie spielt: 
	einen Normalen Zauber mit 180 Base Damage Punkten 
	Normal -> Water => EFFECT Damage*2=360
	No Dodge!

banane spielt: 
	einen Wasser Drachen mit 190 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
banane has won this Round with 190

-------------Runde 4-------------
	raphie has won 0 Runden and has 1 Cards
	banane has won 3 Runden and has 7 Cards

raphie spielt: 
	einen Normalen Zauber mit 180 Base Damage Punkten 
	Normal -> Water => EFFECT Damage*2=360
	No Dodge!

banane spielt: 
	einen Wasser Drachen mit 190 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
banane has won this Round with 190
##################################
banane hat Gewonnen!
raphie hat verloren :0');
INSERT INTO public.battlelog (battle_id, playerone, playertwo, isbattlefinished, log) VALUES (9, 'kienboec', 'test', true, '-------------Runde 1-------------
	kienboec has won 0 Runden and has 4 Cards
	test has won 0 Runden and has 2 Cards

kienboec spielt: 
	einen Normalen Drachen mit 160 Base Damage Punkten 
	No Effects
	No Dodge!

test spielt: 
	einen Normalen Goblin mit 120 Base Damage Punkten 
	No Effects
	Goblin hat zu viel Angst vor dem Drachen und greift nicht an_______________________________________
kienboec has won this Round with 160

-------------Runde 2-------------
	kienboec has won 1 Runden and has 5 Cards
	test has won 0 Runden and has 1 Cards

kienboec spielt: 
	einen Wasser Goblin mit 170 Base Damage Punkten 
	No Effects
	No Dodge!

test spielt: 
	einen Feuer Zauber mit 100 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
kienboec has won this Round with 170
##################################
kienboec hat Gewonnen!
test hat verloren :0');
INSERT INTO public.battlelog (battle_id, playerone, playertwo, isbattlefinished, log) VALUES (19, 'kienboec', 'altenhof', true, '-------------Runde 1-------------
	kienboec has won 0 Runden and has 4 Cards
	altenhof has won 0 Runden and has 4 Cards

kienboec spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!

altenhof spielt: 
	einen Normalen Kraken mit 170 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
altenhof has won this Round with 170

-------------Runde 2-------------
	kienboec has won 0 Runden and has 3 Cards
	altenhof has won 1 Runden and has 5 Cards

kienboec spielt: 
	einen Normalen Drachen mit 160 Base Damage Punkten 
	No Effects
	No Dodge!

altenhof spielt: 
	einen Normalen Knight mit 120 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
kienboec has won this Round with 160

-------------Runde 3-------------
	kienboec has won 1 Runden and has 4 Cards
	altenhof has won 1 Runden and has 4 Cards

kienboec spielt: 
	einen Normalen Drachen mit 160 Base Damage Punkten 
	No Effects
	No Dodge!

altenhof spielt: 
	einen Normalen Kraken mit 170 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
altenhof has won this Round with 170

-------------Runde 4-------------
	kienboec has won 1 Runden and has 3 Cards
	altenhof has won 2 Runden and has 5 Cards

kienboec spielt: 
	einen Wasser Knight mit 100 Base Damage Punkten 
	No Effects
	No Dodge!

altenhof spielt: 
	einen Normalen Kraken mit 170 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
altenhof has won this Round with 170

-------------Runde 5-------------
	kienboec has won 1 Runden and has 2 Cards
	altenhof has won 3 Runden and has 6 Cards

kienboec spielt: 
	einen Wasser Knight mit 100 Base Damage Punkten 
	No Effects
	No Dodge!

altenhof spielt: 
	einen Feuer Goblin mit 170 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
altenhof has won this Round with 170

-------------Runde 6-------------
	kienboec has won 1 Runden and has 1 Cards
	altenhof has won 4 Runden and has 7 Cards

kienboec spielt: 
	einen Wasser Knight mit 100 Base Damage Punkten 
	No Effects
	No Dodge!

altenhof spielt: 
	einen Wasser Zauber mit 190 Base Damage Punkten 
	Knight Drawned in Water Spell => Dead
	No Dodge!
_______________________________________
altenhof has won this Round with 190


##################################
altenhof hat Gewonnen!
kienboec hat verloren :0');
INSERT INTO public.battlelog (battle_id, playerone, playertwo, isbattlefinished, log) VALUES (6, 'test', 'fest', true, '-------------Runde 1-------------
	test has won 0 Runden and has 2 Cards
	fest has won 0 Runden and has 3 Cards

test spielt: 
	einen Normalen Goblin mit 120 Base Damage Punkten 
	No Effects
	No Dodge!

fest spielt: 
	einen Normalen Goblin mit 180 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
fest has won this Round with 180

-------------Runde 2-------------
	test has won 0 Runden and has 1 Cards
	fest has won 1 Runden and has 4 Cards

test spielt: 
	einen Feuer Zauber mit 100 Base Damage Punkten 
	Kraken immune against spells => NO EFFECT 
	No Dodge!

fest spielt: 
	einen Normalen Kraken mit 150 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
fest has won this Round with 150
##################################
fest hat Gewonnen!
test hat verloren :0');
INSERT INTO public.battlelog (battle_id, playerone, playertwo, isbattlefinished, log) VALUES (7, 'test', 'fest', true, '-------------Runde 1-------------
	test has won 0 Runden and has 2 Cards
	fest has won 0 Runden and has 3 Cards

test spielt: 
	einen Normalen Goblin mit 120 Base Damage Punkten 
	No Effects
	No Dodge!

fest spielt: 
	einen Normalen Goblin mit 180 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
fest has won this Round with 180

-------------Runde 2-------------
	test has won 0 Runden and has 1 Cards
	fest has won 1 Runden and has 4 Cards

test spielt: 
	einen Feuer Zauber mit 100 Base Damage Punkten 
	Fire -> Normal => EFFECT Damage*2=200
	No Dodge!

fest spielt: 
	einen Normalen Goblin mit 180 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
fest has won this Round with 180
##################################
fest hat Gewonnen!
test hat verloren :0');
INSERT INTO public.battlelog (battle_id, playerone, playertwo, isbattlefinished, log) VALUES (20, 'kienboec', 'altenhof', true, '-------------Runde 1-------------
	kienboec has won 0 Runden and has 4 Cards
	altenhof has won 0 Runden and has 4 Cards

kienboec spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!

altenhof spielt: 
	einen Normalen Kraken mit 170 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
altenhof has won this Round with 170

-------------Runde 2-------------
	kienboec has won 0 Runden and has 3 Cards
	altenhof has won 1 Runden and has 5 Cards

kienboec spielt: 
	einen Wasser Knight mit 100 Base Damage Punkten 
	No Effects
	No Dodge!

altenhof spielt: 
	einen Feuer Goblin mit 170 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
altenhof has won this Round with 170

-------------Runde 3-------------
	kienboec has won 0 Runden and has 2 Cards
	altenhof has won 2 Runden and has 6 Cards

kienboec spielt: 
	einen Normalen Drachen mit 160 Base Damage Punkten 
	No Effects
	No Dodge!

altenhof spielt: 
	einen Feuer Goblin mit 170 Base Damage Punkten 
	No Effects
	Goblin hat zu viel Angst vor dem Drachen und greift nicht an_______________________________________
altenhof has won this Round with 170

-------------Runde 4-------------
	kienboec has won 0 Runden and has 1 Cards
	altenhof has won 3 Runden and has 7 Cards

kienboec spielt: 
	einen Wasser Goblin mit 170 Base Damage Punkten 
	No Effects
	No Dodge!

altenhof spielt: 
	einen Wasser Zauber mit 190 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
altenhof has won this Round with 190


##################################
altenhof hat Gewonnen!
kienboec hat verloren :0');
INSERT INTO public.battlelog (battle_id, playerone, playertwo, isbattlefinished, log) VALUES (17, 'banane', 'raphie', true, '-------------Runde 1-------------
	banane has won 0 Runden and has 4 Cards
	raphie has won 0 Runden and has 4 Cards

banane spielt: 
	einen Feuer Knight mit 190 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Wasser Zauber mit 100 Base Damage Punkten 
	Knight Drawned in Water Spell => Dead
	No Dodge!
_______________________________________
banane has won this Round with 190

-------------Runde 2-------------
	banane has won 1 Runden and has 5 Cards
	raphie has won 0 Runden and has 3 Cards

banane spielt: 
	einen Normalen Drachen mit 190 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Normalen Zauber mit 100 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
banane has won this Round with 190

-------------Runde 3-------------
	banane has won 2 Runden and has 6 Cards
	raphie has won 0 Runden and has 2 Cards

banane spielt: 
	einen Normalen Drachen mit 190 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Normalen Zauber mit 100 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
banane has won this Round with 190

-------------Runde 4-------------
	banane has won 3 Runden and has 7 Cards
	raphie has won 0 Runden and has 1 Cards

banane spielt: 
	einen Wasser Knight mit 190 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Normalen Zauber mit 100 Base Damage Punkten 
	Normal -> Water => EFFECT Damage*2=200
	No Dodge!
_______________________________________
banane has won this Round with 190
##################################
banane hat Gewonnen!
raphie hat verloren :0');
INSERT INTO public.battlelog (battle_id, playerone, playertwo, isbattlefinished, log) VALUES (12, 'kienboec', 'banane', true, '-------------Runde 1-------------
	kienboec has won 0 Runden and has 4 Cards
	banane has won 0 Runden and has 4 Cards

kienboec spielt: 
	einen Normalen Drachen mit 160 Base Damage Punkten 
	No Effects
	No Dodge!

banane spielt: 
	einen Wasser Drachen mit 190 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
banane has won this Round with 190

-------------Runde 2-------------
	kienboec has won 0 Runden and has 3 Cards
	banane has won 1 Runden and has 5 Cards

kienboec spielt: 
	einen Wasser Knight mit 100 Base Damage Punkten 
	No Effects
	No Dodge!

banane spielt: 
	einen Wasser Knight mit 190 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
banane has won this Round with 190

-------------Runde 3-------------
	kienboec has won 0 Runden and has 2 Cards
	banane has won 2 Runden and has 6 Cards

kienboec spielt: 
	einen Wasser Knight mit 100 Base Damage Punkten 
	No Effects
	No Dodge!

banane spielt: 
	einen Normalen Drachen mit 190 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
banane has won this Round with 190

-------------Runde 4-------------
	kienboec has won 0 Runden and has 1 Cards
	banane has won 3 Runden and has 7 Cards

kienboec spielt: 
	einen Wasser Knight mit 100 Base Damage Punkten 
	No Effects
	No Dodge!

banane spielt: 
	einen Feuer Knight mit 190 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
banane has won this Round with 190
##################################
banane hat Gewonnen!
kienboec hat verloren :0');
INSERT INTO public.battlelog (battle_id, playerone, playertwo, isbattlefinished, log) VALUES (13, 'kienboec', 'raphie', true, '-------------Runde 1-------------
	kienboec has won 0 Runden and has 4 Cards
	raphie has won 0 Runden and has 4 Cards

kienboec spielt: 
	einen Normalen Drachen mit 160 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Normalen Zauber mit 100 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
kienboec has won this Round with 160

-------------Runde 2-------------
	kienboec has won 1 Runden and has 5 Cards
	raphie has won 0 Runden and has 3 Cards

kienboec spielt: 
	einen Wasser Knight mit 100 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Normalen Zauber mit 180 Base Damage Punkten 
	Normal -> Water => EFFECT Damage*2=360
	No Dodge!
_______________________________________
raphie has won this Round with 180

-------------Runde 3-------------
	kienboec has won 1 Runden and has 4 Cards
	raphie has won 1 Runden and has 4 Cards

kienboec spielt: 
	einen Normalen Drachen mit 160 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Normalen Zauber mit 180 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
raphie has won this Round with 180

-------------Runde 4-------------
	kienboec has won 1 Runden and has 3 Cards
	raphie has won 2 Runden and has 5 Cards

kienboec spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Normalen Zauber mit 180 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
raphie has won this Round with 180

-------------Runde 5-------------
	kienboec has won 1 Runden and has 2 Cards
	raphie has won 3 Runden and has 6 Cards

kienboec spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Normalen Drachen mit 160 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
raphie has won this Round with 160

-------------Runde 6-------------
	kienboec has won 1 Runden and has 1 Cards
	raphie has won 4 Runden and has 7 Cards

kienboec spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Wasser Zauber mit 100 Base Damage Punkten 
	Water -> Fire => EFFECT Damage*2=200
	No Dodge!
_______________________________________
kienboec has won this Round with 130

-------------Runde 7-------------
	kienboec has won 2 Runden and has 2 Cards
	raphie has won 4 Runden and has 6 Cards

kienboec spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Normalen Zauber mit 180 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
raphie has won this Round with 180

-------------Runde 8-------------
	kienboec has won 2 Runden and has 1 Cards
	raphie has won 5 Runden and has 7 Cards

kienboec spielt: 
	einen Wasser Zauber mit 100 Base Damage Punkten 
	No Effects
	No Dodge!

raphie spielt: 
	einen Normalen Zauber mit 180 Base Damage Punkten 
	Normal -> Water => EFFECT Damage*2=360
	No Dodge!
_______________________________________
raphie has won this Round with 180
##################################
raphie hat Gewonnen!
kienboec hat verloren :0');
INSERT INTO public.battlelog (battle_id, playerone, playertwo, isbattlefinished, log) VALUES (8, 'fest', 'kienboec', true, '-------------Runde 1-------------
	fest has won 0 Runden and has 3 Cards
	kienboec has won 0 Runden and has 4 Cards

fest spielt: 
	einen Normalen Goblin mit 180 Base Damage Punkten 
	No Effects
	No Dodge!

kienboec spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
fest has won this Round with 180

-------------Runde 2-------------
	fest has won 1 Runden and has 4 Cards
	kienboec has won 0 Runden and has 3 Cards

fest spielt: 
	einen Wasser Wizard mit 180 Base Damage Punkten 
	No Effects
	No Dodge!

kienboec spielt: 
	einen Normalen Drachen mit 160 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
fest has won this Round with 180

-------------Runde 3-------------
	fest has won 2 Runden and has 5 Cards
	kienboec has won 0 Runden and has 2 Cards

fest spielt: 
	einen Wasser Wizard mit 180 Base Damage Punkten 
	No Effects
	No Dodge!

kienboec spielt: 
	einen Wasser Knight mit 100 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
fest has won this Round with 180

-------------Runde 4-------------
	fest has won 3 Runden and has 6 Cards
	kienboec has won 0 Runden and has 1 Cards

fest spielt: 
	einen Wasser Wizard mit 180 Base Damage Punkten 
	No Effects
	No Dodge!

kienboec spielt: 
	einen Wasser Knight mit 100 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
fest has won this Round with 180
##################################
fest hat Gewonnen!
kienboec hat verloren :0');
INSERT INTO public.battlelog (battle_id, playerone, playertwo, isbattlefinished, log) VALUES (2, 'kienboec', 'fest', true, '-------------Runde 1-------------
	kienboec has won 0 Runden and has 4 Cards
	fest has won 0 Runden and has 3 Cards

kienboec spielt: 
	einen Wasser Knight mit 100 Base Damage Punkten 
	No Effects
	No Dodge!

fest spielt: 
	einen Wasser Wizard mit 180 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
fest has won this Round with 180

-------------Runde 2-------------
	kienboec has won 0 Runden and has 3 Cards
	fest has won 1 Runden and has 4 Cards

kienboec spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!

fest spielt: 
	einen Normalen Kraken mit 150 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
fest has won this Round with 150

-------------Runde 3-------------
	kienboec has won 0 Runden and has 2 Cards
	fest has won 2 Runden and has 5 Cards

kienboec spielt: 
	einen Normalen Drachen mit 160 Base Damage Punkten 
	No Effects
	No Dodge!

fest spielt: 
	einen Wasser Knight mit 100 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
kienboec has won this Round with 160

-------------Runde 4-------------
	kienboec has won 1 Runden and has 3 Cards
	fest has won 2 Runden and has 4 Cards

kienboec spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!

fest spielt: 
	einen Normalen Kraken mit 150 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
fest has won this Round with 150

-------------Runde 5-------------
	kienboec has won 1 Runden and has 2 Cards
	fest has won 3 Runden and has 5 Cards

kienboec spielt: 
	einen Normalen Drachen mit 160 Base Damage Punkten 
	No Effects
	No Dodge!

fest spielt: 
	einen Normalen Kraken mit 150 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
kienboec has won this Round with 160

-------------Runde 6-------------
	kienboec has won 2 Runden and has 3 Cards
	fest has won 3 Runden and has 4 Cards

kienboec spielt: 
	einen Normalen Drachen mit 160 Base Damage Punkten 
	No Effects
	No Dodge!

fest spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
kienboec has won this Round with 160

-------------Runde 7-------------
	kienboec has won 3 Runden and has 4 Cards
	fest has won 3 Runden and has 3 Cards

kienboec spielt: 
	einen Normalen Drachen mit 160 Base Damage Punkten 
	No Effects
	No Dodge!

fest spielt: 
	einen Normalen Goblin mit 180 Base Damage Punkten 
	No Effects
	Goblin hat zu viel Angst vor dem Drachen und greift nicht an_______________________________________
fest has won this Round with 180

-------------Runde 8-------------
	kienboec has won 3 Runden and has 3 Cards
	fest has won 4 Runden and has 4 Cards

kienboec spielt: 
	einen Wasser Knight mit 100 Base Damage Punkten 
	No Effects
	No Dodge!

fest spielt: 
	einen Normalen Goblin mit 180 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
fest has won this Round with 180

-------------Runde 9-------------
	kienboec has won 3 Runden and has 2 Cards
	fest has won 5 Runden and has 5 Cards

kienboec spielt: 
	einen Wasser Knight mit 100 Base Damage Punkten 
	No Effects
	No Dodge!

fest spielt: 
	einen Normalen Drachen mit 160 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
fest has won this Round with 160

-------------Runde 10-------------
	kienboec has won 3 Runden and has 1 Cards
	fest has won 6 Runden and has 6 Cards

kienboec spielt: 
	einen Wasser Knight mit 100 Base Damage Punkten 
	No Effects
	No Dodge!

fest spielt: 
	einen Wasser Knight mit 100 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
kienboec and fest has the same Damage points [TIE]

-------------Runde 11-------------
	kienboec has won 3 Runden and has 1 Cards
	fest has won 6 Runden and has 6 Cards

kienboec spielt: 
	einen Wasser Knight mit 100 Base Damage Punkten 
	No Effects
	No Dodge!

fest spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
fest has won this Round with 130
##################################
fest hat Gewonnen!
kienboec hat verloren :0');
INSERT INTO public.battlelog (battle_id, playerone, playertwo, isbattlefinished, log) VALUES (4, 'kienboec', 'fest', true, '-------------Runde 1-------------
	kienboec has won 0 Runden and has 4 Cards
	fest has won 0 Runden and has 3 Cards

kienboec spielt: 
	einen Wasser Knight mit 100 Base Damage Punkten 
	No Effects
	No Dodge!

fest spielt: 
	einen Normalen Goblin mit 180 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
fest has won this Round with 180

-------------Runde 2-------------
	kienboec has won 0 Runden and has 3 Cards
	fest has won 1 Runden and has 4 Cards

kienboec spielt: 
	einen Normalen Drachen mit 160 Base Damage Punkten 
	No Effects
	No Dodge!

fest spielt: 
	einen Wasser Wizard mit 180 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
fest has won this Round with 180

-------------Runde 3-------------
	kienboec has won 0 Runden and has 2 Cards
	fest has won 2 Runden and has 5 Cards

kienboec spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!

fest spielt: 
	einen Normalen Kraken mit 150 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
fest has won this Round with 150

-------------Runde 4-------------
	kienboec has won 0 Runden and has 1 Cards
	fest has won 3 Runden and has 6 Cards

kienboec spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!

fest spielt: 
	einen Wasser Wizard mit 180 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
fest has won this Round with 180
##################################
fest hat Gewonnen!
kienboec hat verloren :0');
INSERT INTO public.battlelog (battle_id, playerone, playertwo, isbattlefinished, log) VALUES (10, 'kienboec', 'fest', true, '-------------Runde 1-------------
	kienboec has won 0 Runden and has 4 Cards
	fest has won 0 Runden and has 3 Cards

kienboec spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!

fest spielt: 
	einen Wasser Wizard mit 180 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
fest has won this Round with 180

-------------Runde 2-------------
	kienboec has won 0 Runden and has 3 Cards
	fest has won 1 Runden and has 4 Cards

kienboec spielt: 
	einen Normalen Drachen mit 160 Base Damage Punkten 
	No Effects
	No Dodge!

fest spielt: 
	einen Normalen Goblin mit 180 Base Damage Punkten 
	No Effects
	Goblin hat zu viel Angst vor dem Drachen und greift nicht an_______________________________________
fest has won this Round with 180

-------------Runde 3-------------
	kienboec has won 0 Runden and has 2 Cards
	fest has won 2 Runden and has 5 Cards

kienboec spielt: 
	einen Wasser Knight mit 100 Base Damage Punkten 
	No Effects
	No Dodge!

fest spielt: 
	einen Feuer Wizard mit 130 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
fest has won this Round with 130

-------------Runde 4-------------
	kienboec has won 0 Runden and has 1 Cards
	fest has won 3 Runden and has 6 Cards

kienboec spielt: 
	einen Wasser Knight mit 100 Base Damage Punkten 
	No Effects
	No Dodge!

fest spielt: 
	einen Wasser Wizard mit 180 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
fest has won this Round with 180
##################################
fest hat Gewonnen!
kienboec hat verloren :0');
INSERT INTO public.battlelog (battle_id, playerone, playertwo, isbattlefinished, log) VALUES (15, 'banane', 'fest', true, '-------------Runde 1-------------
	banane has won 0 Runden and has 4 Cards
	fest has won 0 Runden and has 3 Cards

banane spielt: 
	einen Feuer Knight mit 190 Base Damage Punkten 
	No Effects
	No Dodge!

fest spielt: 
	einen Wasser Wizard mit 180 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
banane has won this Round with 190

-------------Runde 2-------------
	banane has won 1 Runden and has 5 Cards
	fest has won 0 Runden and has 2 Cards

banane spielt: 
	einen Wasser Drachen mit 190 Base Damage Punkten 
	No Effects
	No Dodge!

fest spielt: 
	einen Normalen Goblin mit 180 Base Damage Punkten 
	No Effects
	Goblin hat zu viel Angst vor dem Drachen und greift nicht an_______________________________________
banane has won this Round with 190

-------------Runde 3-------------
	banane has won 2 Runden and has 6 Cards
	fest has won 0 Runden and has 1 Cards

banane spielt: 
	einen Feuer Knight mit 190 Base Damage Punkten 
	No Effects
	No Dodge!

fest spielt: 
	einen Normalen Goblin mit 180 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
banane has won this Round with 190
##################################
banane hat Gewonnen!
fest hat verloren :0');
INSERT INTO public.battlelog (battle_id, playerone, playertwo, isbattlefinished, log) VALUES (16, 'banane', 'test', true, '-------------Runde 1-------------
	banane has won 0 Runden and has 4 Cards
	test has won 0 Runden and has 2 Cards

banane spielt: 
	einen Normalen Drachen mit 190 Base Damage Punkten 
	No Effects
	No Dodge!

test spielt: 
	einen Normalen Goblin mit 120 Base Damage Punkten 
	No Effects
	Goblin hat zu viel Angst vor dem Drachen und greift nicht an_______________________________________
banane has won this Round with 190

-------------Runde 2-------------
	banane has won 1 Runden and has 5 Cards
	test has won 0 Runden and has 1 Cards

banane spielt: 
	einen Wasser Drachen mit 190 Base Damage Punkten 
	No Effects
	No Dodge!

test spielt: 
	einen Feuer Zauber mit 100 Base Damage Punkten 
	No Effects
	No Dodge!
_______________________________________
banane has won this Round with 190
##################################
banane hat Gewonnen!
test hat verloren :0');


--
-- TOC entry 3057 (class 0 OID 16414)
-- Dependencies: 203
-- Data for Name: cards; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (2, 1, 1, 100, 'Drache oder so', 1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (3, 1, 1, 110, 'Drache oder so', 1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (4, 1, 1, 120, 'Drache oder so', 1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (5, 1, 1, 130, 'Drache oder so', 1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (6, 1, 1, 140, 'Drache oder so', 1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (7, 1, 1, 150, 'Drache oder so', 1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (8, 1, 1, 160, 'Drache oder so', 1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (9, 1, 1, 170, 'Drache oder so', 1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (10, 1, 1, 180, 'Drache oder so', 1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (11, 1, 1, 190, 'Drache oder so', 1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (12, 1, 2, 100, 'Drache oder so', 1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (13, 1, 2, 110, 'Drache oder so', 1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (14, 1, 2, 120, 'Drache oder so', 1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (15, 1, 2, 130, 'Drache oder so', 1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (16, 1, 2, 140, 'Drache oder so', 1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (17, 1, 2, 150, 'Drache oder so', 1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (18, 1, 2, 160, 'Drache oder so', 1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (19, 1, 2, 170, 'Drache oder so', 1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (20, 1, 2, 180, 'Drache oder so', 1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (21, 1, 2, 190, 'Drache oder so', 1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (22, 1, 3, 100, 'Drache oder so', 1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (23, 1, 3, 110, 'Drache oder so', 1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (24, 1, 3, 120, 'Drache oder so', 1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (25, 1, 3, 130, 'Drache oder so', 1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (26, 1, 3, 140, 'Drache oder so', 1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (27, 1, 3, 150, 'Drache oder so', 1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (28, 1, 3, 160, 'Drache oder so', 1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (29, 1, 3, 170, 'Drache oder so', 1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (30, 1, 3, 180, 'Drache oder so', 1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (31, 1, 3, 190, 'Drache oder so', 1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (109, 1, 2, 170, 'Ich bin ein Witz art', 4);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (110, 1, 2, 180, 'Ich bin ein Witz art', 4);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (111, 1, 2, 190, 'Ich bin ein Witz art', 4);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (112, 1, 3, 100, 'Ich bin ein Witz art', 4);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (212, 2, 1, 100, 'Fire Spell', -1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (213, 2, 1, 110, 'Fire Spell', -1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (214, 2, 1, 120, 'Fire Spell', -1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (215, 2, 1, 130, 'Fire Spell', -1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (216, 2, 1, 140, 'Fire Spell', -1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (217, 2, 1, 150, 'Fire Spell', -1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (218, 2, 1, 160, 'Fire Spell', -1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (219, 2, 1, 170, 'Fire Spell', -1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (220, 2, 1, 180, 'Fire Spell', -1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (221, 2, 1, 190, 'Fire Spell', -1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (222, 2, 2, 100, 'Water Spell', -1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (223, 2, 2, 110, 'Water Spell', -1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (224, 2, 2, 120, 'Water Spell', -1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (225, 2, 2, 130, 'Water Spell', -1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (226, 2, 2, 140, 'Water Spell', -1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (227, 2, 2, 150, 'Water Spell', -1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (228, 2, 2, 160, 'Water Spell', -1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (229, 2, 2, 170, 'Water Spell', -1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (230, 2, 2, 180, 'Water Spell', -1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (231, 2, 2, 190, 'Water Spell', -1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (232, 2, 3, 100, 'Normal Spell', -1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (233, 2, 3, 110, 'Normal Spell', -1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (234, 2, 3, 120, 'Normal Spell', -1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (235, 2, 3, 130, 'Normal Spell', -1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (236, 2, 3, 140, 'Normal Spell', -1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (237, 2, 3, 150, 'Normal Spell', -1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (238, 2, 3, 160, 'Normal Spell', -1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (239, 2, 3, 170, 'Normal Spell', -1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (240, 2, 3, 180, 'Normal Spell', -1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (241, 2, 3, 190, 'Normal Spell', -1);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (32, 1, 1, 100, 'Knight in the Night, just Right', 2);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (33, 1, 1, 110, 'Knight in the Night, just Right', 2);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (34, 1, 1, 120, 'Knight in the Night, just Right', 2);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (35, 1, 1, 130, 'Knight in the Night, just Right', 2);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (36, 1, 1, 140, 'Knight in the Night, just Right', 2);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (37, 1, 1, 150, 'Knight in the Night, just Right', 2);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (38, 1, 1, 160, 'Knight in the Night, just Right', 2);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (39, 1, 1, 170, 'Knight in the Night, just Right', 2);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (40, 1, 1, 180, 'Knight in the Night, just Right', 2);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (41, 1, 1, 190, 'Knight in the Night, just Right', 2);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (42, 1, 2, 100, 'Knight in the Night, just Right', 2);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (43, 1, 2, 110, 'Knight in the Night, just Right', 2);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (44, 1, 2, 120, 'Knight in the Night, just Right', 2);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (45, 1, 2, 130, 'Knight in the Night, just Right', 2);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (46, 1, 2, 140, 'Knight in the Night, just Right', 2);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (47, 1, 2, 150, 'Knight in the Night, just Right', 2);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (48, 1, 2, 160, 'Knight in the Night, just Right', 2);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (49, 1, 2, 170, 'Knight in the Night, just Right', 2);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (50, 1, 2, 180, 'Knight in the Night, just Right', 2);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (51, 1, 2, 190, 'Knight in the Night, just Right', 2);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (52, 1, 3, 100, 'Knight in the Night, just Right', 2);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (53, 1, 3, 110, 'Knight in the Night, just Right', 2);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (54, 1, 3, 120, 'Knight in the Night, just Right', 2);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (55, 1, 3, 130, 'Knight in the Night, just Right', 2);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (56, 1, 3, 140, 'Knight in the Night, just Right', 2);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (57, 1, 3, 150, 'Knight in the Night, just Right', 2);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (58, 1, 3, 160, 'Knight in the Night, just Right', 2);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (59, 1, 3, 170, 'Knight in the Night, just Right', 2);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (60, 1, 3, 180, 'Knight in the Night, just Right', 2);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (61, 1, 3, 190, 'Knight in the Night, just Right', 2);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (62, 1, 1, 100, 'Ich bin Orrg und du?', 3);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (63, 1, 1, 110, 'Ich bin Orrg und du?', 3);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (64, 1, 1, 120, 'Ich bin Orrg und du?', 3);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (65, 1, 1, 130, 'Ich bin Orrg und du?', 3);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (66, 1, 1, 140, 'Ich bin Orrg und du?', 3);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (67, 1, 1, 150, 'Ich bin Orrg und du?', 3);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (68, 1, 1, 160, 'Ich bin Orrg und du?', 3);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (69, 1, 1, 170, 'Ich bin Orrg und du?', 3);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (70, 1, 1, 180, 'Ich bin Orrg und du?', 3);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (71, 1, 1, 190, 'Ich bin Orrg und du?', 3);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (72, 1, 2, 100, 'Ich bin Orrg und du?', 3);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (73, 1, 2, 110, 'Ich bin Orrg und du?', 3);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (74, 1, 2, 120, 'Ich bin Orrg und du?', 3);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (75, 1, 2, 130, 'Ich bin Orrg und du?', 3);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (76, 1, 2, 140, 'Ich bin Orrg und du?', 3);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (77, 1, 2, 150, 'Ich bin Orrg und du?', 3);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (78, 1, 2, 160, 'Ich bin Orrg und du?', 3);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (79, 1, 2, 170, 'Ich bin Orrg und du?', 3);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (80, 1, 2, 180, 'Ich bin Orrg und du?', 3);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (81, 1, 2, 190, 'Ich bin Orrg und du?', 3);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (82, 1, 3, 100, 'Ich bin Orrg und du?', 3);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (83, 1, 3, 110, 'Ich bin Orrg und du?', 3);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (84, 1, 3, 120, 'Ich bin Orrg und du?', 3);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (85, 1, 3, 130, 'Ich bin Orrg und du?', 3);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (86, 1, 3, 140, 'Ich bin Orrg und du?', 3);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (87, 1, 3, 150, 'Ich bin Orrg und du?', 3);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (88, 1, 3, 160, 'Ich bin Orrg und du?', 3);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (89, 1, 3, 170, 'Ich bin Orrg und du?', 3);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (90, 1, 3, 180, 'Ich bin Orrg und du?', 3);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (91, 1, 3, 190, 'Ich bin Orrg und du?', 3);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (92, 1, 1, 100, 'Ich bin ein Witz art', 4);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (93, 1, 1, 110, 'Ich bin ein Witz art', 4);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (94, 1, 1, 120, 'Ich bin ein Witz art', 4);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (95, 1, 1, 130, 'Ich bin ein Witz art', 4);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (96, 1, 1, 140, 'Ich bin ein Witz art', 4);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (97, 1, 1, 150, 'Ich bin ein Witz art', 4);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (98, 1, 1, 160, 'Ich bin ein Witz art', 4);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (99, 1, 1, 170, 'Ich bin ein Witz art', 4);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (100, 1, 1, 180, 'Ich bin ein Witz art', 4);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (101, 1, 1, 190, 'Ich bin ein Witz art', 4);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (102, 1, 2, 100, 'Ich bin ein Witz art', 4);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (103, 1, 2, 110, 'Ich bin ein Witz art', 4);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (104, 1, 2, 120, 'Ich bin ein Witz art', 4);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (105, 1, 2, 130, 'Ich bin ein Witz art', 4);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (106, 1, 2, 140, 'Ich bin ein Witz art', 4);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (107, 1, 2, 150, 'Ich bin ein Witz art', 4);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (108, 1, 2, 160, 'Ich bin ein Witz art', 4);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (113, 1, 3, 110, 'Ich bin ein Witz art', 4);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (114, 1, 3, 120, 'Ich bin ein Witz art', 4);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (115, 1, 3, 130, 'Ich bin ein Witz art', 4);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (116, 1, 3, 140, 'Ich bin ein Witz art', 4);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (117, 1, 3, 150, 'Ich bin ein Witz art', 4);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (118, 1, 3, 160, 'Ich bin ein Witz art', 4);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (119, 1, 3, 170, 'Ich bin ein Witz art', 4);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (120, 1, 3, 180, 'Ich bin ein Witz art', 4);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (121, 1, 3, 190, 'Ich bin ein Witz art', 4);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (122, 1, 1, 100, 'Gobster the Robster', 5);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (123, 1, 1, 110, 'Gobster the Robster', 5);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (124, 1, 1, 120, 'Gobster the Robster', 5);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (125, 1, 1, 130, 'Gobster the Robster', 5);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (126, 1, 1, 140, 'Gobster the Robster', 5);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (127, 1, 1, 150, 'Gobster the Robster', 5);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (128, 1, 1, 160, 'Gobster the Robster', 5);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (129, 1, 1, 170, 'Gobster the Robster', 5);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (130, 1, 1, 180, 'Gobster the Robster', 5);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (131, 1, 1, 190, 'Gobster the Robster', 5);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (132, 1, 2, 100, 'Gobster the Robster', 5);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (133, 1, 2, 110, 'Gobster the Robster', 5);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (134, 1, 2, 120, 'Gobster the Robster', 5);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (135, 1, 2, 130, 'Gobster the Robster', 5);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (136, 1, 2, 140, 'Gobster the Robster', 5);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (137, 1, 2, 150, 'Gobster the Robster', 5);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (138, 1, 2, 160, 'Gobster the Robster', 5);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (139, 1, 2, 170, 'Gobster the Robster', 5);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (140, 1, 2, 180, 'Gobster the Robster', 5);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (141, 1, 2, 190, 'Gobster the Robster', 5);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (142, 1, 3, 100, 'Gobster the Robster', 5);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (143, 1, 3, 110, 'Gobster the Robster', 5);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (144, 1, 3, 120, 'Gobster the Robster', 5);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (145, 1, 3, 130, 'Gobster the Robster', 5);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (146, 1, 3, 140, 'Gobster the Robster', 5);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (147, 1, 3, 150, 'Gobster the Robster', 5);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (148, 1, 3, 160, 'Gobster the Robster', 5);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (149, 1, 3, 170, 'Gobster the Robster', 5);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (150, 1, 3, 180, 'Gobster the Robster', 5);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (151, 1, 3, 190, 'Gobster the Robster', 5);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (152, 1, 1, 100, 'Krakie dakie do whatcha gonna do', 6);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (153, 1, 1, 110, 'Krakie dakie do whatcha gonna do', 6);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (154, 1, 1, 120, 'Krakie dakie do whatcha gonna do', 6);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (155, 1, 1, 130, 'Krakie dakie do whatcha gonna do', 6);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (156, 1, 1, 140, 'Krakie dakie do whatcha gonna do', 6);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (157, 1, 1, 150, 'Krakie dakie do whatcha gonna do', 6);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (158, 1, 1, 160, 'Krakie dakie do whatcha gonna do', 6);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (159, 1, 1, 170, 'Krakie dakie do whatcha gonna do', 6);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (160, 1, 1, 180, 'Krakie dakie do whatcha gonna do', 6);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (161, 1, 1, 190, 'Krakie dakie do whatcha gonna do', 6);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (162, 1, 2, 100, 'Krakie dakie do whatcha gonna do', 6);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (163, 1, 2, 110, 'Krakie dakie do whatcha gonna do', 6);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (164, 1, 2, 120, 'Krakie dakie do whatcha gonna do', 6);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (165, 1, 2, 130, 'Krakie dakie do whatcha gonna do', 6);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (166, 1, 2, 140, 'Krakie dakie do whatcha gonna do', 6);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (167, 1, 2, 150, 'Krakie dakie do whatcha gonna do', 6);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (168, 1, 2, 160, 'Krakie dakie do whatcha gonna do', 6);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (169, 1, 2, 170, 'Krakie dakie do whatcha gonna do', 6);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (170, 1, 2, 180, 'Krakie dakie do whatcha gonna do', 6);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (171, 1, 2, 190, 'Krakie dakie do whatcha gonna do', 6);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (172, 1, 3, 100, 'Krakie dakie do whatcha gonna do', 6);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (173, 1, 3, 110, 'Krakie dakie do whatcha gonna do', 6);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (174, 1, 3, 120, 'Krakie dakie do whatcha gonna do', 6);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (175, 1, 3, 130, 'Krakie dakie do whatcha gonna do', 6);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (176, 1, 3, 140, 'Krakie dakie do whatcha gonna do', 6);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (177, 1, 3, 150, 'Krakie dakie do whatcha gonna do', 6);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (178, 1, 3, 160, 'Krakie dakie do whatcha gonna do', 6);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (179, 1, 3, 170, 'Krakie dakie do whatcha gonna do', 6);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (180, 1, 3, 180, 'Krakie dakie do whatcha gonna do', 6);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (181, 1, 3, 190, 'Krakie dakie do whatcha gonna do', 6);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (182, 1, 1, 100, 'I am Fry the FireFly', 7);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (183, 1, 1, 110, 'I am Fry the FireFly', 7);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (184, 1, 1, 120, 'I am Fry the FireFly', 7);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (185, 1, 1, 130, 'I am Fry the FireFly', 7);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (186, 1, 1, 140, 'I am Fry the FireFly', 7);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (187, 1, 1, 150, 'I am Fry the FireFly', 7);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (188, 1, 1, 160, 'I am Fry the FireFly', 7);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (189, 1, 1, 170, 'I am Fry the FireFly', 7);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (190, 1, 1, 180, 'I am Fry the FireFly', 7);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (191, 1, 1, 190, 'I am Fry the FireFly', 7);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (192, 1, 2, 100, 'I am Fry the FireFly', 7);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (193, 1, 2, 110, 'I am Fry the FireFly', 7);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (194, 1, 2, 120, 'I am Fry the FireFly', 7);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (195, 1, 2, 130, 'I am Fry the FireFly', 7);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (196, 1, 2, 140, 'I am Fry the FireFly', 7);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (197, 1, 2, 150, 'I am Fry the FireFly', 7);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (198, 1, 2, 160, 'I am Fry the FireFly', 7);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (199, 1, 2, 170, 'I am Fry the FireFly', 7);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (200, 1, 2, 180, 'I am Fry the FireFly', 7);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (201, 1, 2, 190, 'I am Fry the FireFly', 7);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (202, 1, 3, 100, 'I am Fry the FireFly', 7);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (203, 1, 3, 110, 'I am Fry the FireFly', 7);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (204, 1, 3, 120, 'I am Fry the FireFly', 7);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (205, 1, 3, 130, 'I am Fry the FireFly', 7);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (206, 1, 3, 140, 'I am Fry the FireFly', 7);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (207, 1, 3, 150, 'I am Fry the FireFly', 7);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (208, 1, 3, 160, 'I am Fry the FireFly', 7);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (209, 1, 3, 170, 'I am Fry the FireFly', 7);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (210, 1, 3, 180, 'I am Fry the FireFly', 7);
INSERT INTO public.cards (card_id, cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (211, 1, 3, 190, 'I am Fry the FireFly', 7);


--
-- TOC entry 3058 (class 0 OID 16448)
-- Dependencies: 204
-- Data for Name: friends; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 3061 (class 0 OID 16566)
-- Dependencies: 207
-- Data for Name: shop; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.shop (pack_id, card_id, cost) VALUES (1, 212, 5);
INSERT INTO public.shop (pack_id, card_id, cost) VALUES (1, 222, 5);
INSERT INTO public.shop (pack_id, card_id, cost) VALUES (1, 232, 5);
INSERT INTO public.shop (pack_id, card_id, cost) VALUES (1, 240, 5);
INSERT INTO public.shop (pack_id, card_id, cost) VALUES (1, 241, 5);
INSERT INTO public.shop (pack_id, card_id, cost) VALUES (2, 12, 5);
INSERT INTO public.shop (pack_id, card_id, cost) VALUES (2, 22, 5);
INSERT INTO public.shop (pack_id, card_id, cost) VALUES (2, 32, 5);
INSERT INTO public.shop (pack_id, card_id, cost) VALUES (3, 39, 5);
INSERT INTO public.shop (pack_id, card_id, cost) VALUES (3, 49, 5);
INSERT INTO public.shop (pack_id, card_id, cost) VALUES (3, 59, 5);
INSERT INTO public.shop (pack_id, card_id, cost) VALUES (3, 19, 5);
INSERT INTO public.shop (pack_id, card_id, cost) VALUES (3, 29, 5);
INSERT INTO public.shop (pack_id, card_id, cost) VALUES (2, 42, 5);
INSERT INTO public.shop (pack_id, card_id, cost) VALUES (2, 52, 5);
INSERT INTO public.shop (pack_id, card_id, cost) VALUES (4, 92, 5);
INSERT INTO public.shop (pack_id, card_id, cost) VALUES (4, 78, 5);
INSERT INTO public.shop (pack_id, card_id, cost) VALUES (4, 6, 5);
INSERT INTO public.shop (pack_id, card_id, cost) VALUES (4, 143, 5);
INSERT INTO public.shop (pack_id, card_id, cost) VALUES (4, 229, 5);
INSERT INTO public.shop (pack_id, card_id, cost) VALUES (5, 84, 5);
INSERT INTO public.shop (pack_id, card_id, cost) VALUES (5, 208, 5);
INSERT INTO public.shop (pack_id, card_id, cost) VALUES (5, 173, 5);
INSERT INTO public.shop (pack_id, card_id, cost) VALUES (5, 232, 5);
INSERT INTO public.shop (pack_id, card_id, cost) VALUES (5, 16, 5);


--
-- TOC entry 3059 (class 0 OID 16521)
-- Dependencies: 205
-- Data for Name: stack; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('test_less_cards', 20, true, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('test', 241, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('test_less_cards', 51, true, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('test_less_cards', 96, true, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('fest', 206, true, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('test', 144, true, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('test', 212, true, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('test', 134, true, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('test', 232, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('test', 240, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('fest', 12, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('fest', 22, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('test', 137, true, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('raphie', 19, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('raphie', 29, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('fest', 32, false, true);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('raphie', 39, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('raphie', 49, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('raphie', 59, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('raphie', 6, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('raphie', 78, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('raphie', 92, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('fest', 222, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('test', 52, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('test', 19, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('test', 29, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('test', 39, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('test', 49, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('test', 59, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('raphie', 143, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('fest', 110, true, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('fest', 150, true, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('fest', 177, true, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('raphie', 229, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('admin', 10, true, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('admin', 41, true, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('admin', 42, true, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('admin', 224, true, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('raphie', 241, true, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('raphie', 240, true, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('raphie', 232, true, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('raphie', 222, true, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('raphie', 212, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('banane', 21, true, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('banane', 31, true, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('banane', 41, true, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('banane', 51, true, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('kienboec', 212, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('kienboec', 222, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('kienboec', 232, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('kienboec', 240, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('kienboec', 241, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('kienboec', 22, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('kienboec', 32, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('kienboec', 52, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('kienboec', 19, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('kienboec', 29, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('kienboec', 39, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('kienboec', 49, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('kienboec', 59, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('kienboec', 78, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('kienboec', 92, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('kienboec', 143, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('kienboec', 229, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('kienboec', 16, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('kienboec', 84, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('kienboec', 173, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('kienboec', 208, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('altenhof', 222, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('altenhof', 232, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('altenhof', 240, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('altenhof', 241, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('kienboec', 28, true, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('kienboec', 42, true, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('kienboec', 95, true, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('kienboec', 139, true, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('altenhof', 22, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('altenhof', 32, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('altenhof', 42, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('altenhof', 52, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('altenhof', 19, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('altenhof', 29, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('altenhof', 39, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('altenhof', 49, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('altenhof', 59, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('altenhof', 78, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('altenhof', 92, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('altenhof', 143, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('altenhof', 229, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('altenhof', 54, true, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('altenhof', 129, true, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('altenhof', 179, true, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('altenhof', 231, true, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('kienboec', 6, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('altenhof', 12, false, false);
INSERT INTO public.stack (username, card_id, isindeck, islocked) VALUES ('test_less_cards', 140, false, false);


--
-- TOC entry 3060 (class 0 OID 16553)
-- Dependencies: 206
-- Data for Name: trade; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.trade (username, wanted_id, give_id) VALUES ('fest', 232, 32);


--
-- TOC entry 3054 (class 0 OID 16395)
-- Dependencies: 200
-- Data for Name: user; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."user" (username, pwd, online, coins, score, wins, lose, spendcoins, gainedcoins, token) VALUES ('fest', 'FEST', false, 20, 117, 9, 2, 0, 0, 348540);
INSERT INTO public."user" (username, pwd, online, coins, score, wins, lose, spendcoins, gainedcoins, token) VALUES ('test', 'TEST', false, 165, 71, 2, 7, 5, 50, 139542);
INSERT INTO public."user" (username, pwd, online, coins, score, wins, lose, spendcoins, gainedcoins, token) VALUES ('banane', 'BANANE', false, 20, 107, 4, 1, 0, 0, 174271);
INSERT INTO public."user" (username, pwd, online, coins, score, wins, lose, spendcoins, gainedcoins, token) VALUES ('altenhof', 'MARKUS', false, 0, 106, 2, 0, 20, 0, 718124);
INSERT INTO public."user" (username, pwd, online, coins, score, wins, lose, spendcoins, gainedcoins, token) VALUES ('kienboec', 'DANIEL', false, 95, 66, 2, 8, 25, 100, 926771);
INSERT INTO public."user" (username, pwd, online, coins, score, wins, lose, spendcoins, gainedcoins, token) VALUES ('test_unit_no_cards', 'TEST', false, 20, 100, 0, 0, 0, 0, 0);
INSERT INTO public."user" (username, pwd, online, coins, score, wins, lose, spendcoins, gainedcoins, token) VALUES ('test_less_cards', 'TEST', false, 20, 100, 0, 0, 0, 0, 274762);
INSERT INTO public."user" (username, pwd, online, coins, score, wins, lose, spendcoins, gainedcoins, token) VALUES ('raphie', 'RAPHIE', false, 50, 93, 1, 2, 20, 50, 322486);
INSERT INTO public."user" (username, pwd, online, coins, score, wins, lose, spendcoins, gainedcoins, token) VALUES ('admin', 'ISTRATOR', false, 20, 100, 0, 0, 0, 0, 227886);


--
-- TOC entry 3070 (class 0 OID 0)
-- Dependencies: 209
-- Name: battle_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.battle_seq', 20, true);


--
-- TOC entry 3071 (class 0 OID 0)
-- Dependencies: 202
-- Name: cards_card_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.cards_card_id_seq', 1, true);


--
-- TOC entry 2915 (class 2606 OID 24700)
-- Name: battlelog battlelog_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.battlelog
    ADD CONSTRAINT battlelog_pkey PRIMARY KEY (battle_id);


--
-- TOC entry 2905 (class 2606 OID 16422)
-- Name: cards cards_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.cards
    ADD CONSTRAINT cards_pkey PRIMARY KEY (card_id);


--
-- TOC entry 2907 (class 2606 OID 16455)
-- Name: friends friends_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.friends
    ADD CONSTRAINT friends_pkey PRIMARY KEY (username);


--
-- TOC entry 2909 (class 2606 OID 16528)
-- Name: stack primary_keys; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.stack
    ADD CONSTRAINT primary_keys PRIMARY KEY (username, card_id);


--
-- TOC entry 2913 (class 2606 OID 16570)
-- Name: shop shop_pkey1; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.shop
    ADD CONSTRAINT shop_pkey1 PRIMARY KEY (pack_id, card_id);


--
-- TOC entry 2911 (class 2606 OID 16560)
-- Name: trade trade_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.trade
    ADD CONSTRAINT trade_pkey PRIMARY KEY (username, wanted_id);


--
-- TOC entry 2903 (class 2606 OID 16403)
-- Name: user user_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."user"
    ADD CONSTRAINT user_pkey PRIMARY KEY (username);


--
-- TOC entry 2922 (class 2606 OID 24701)
-- Name: battlelog battlelog_playerOne_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.battlelog
    ADD CONSTRAINT "battlelog_playerOne_fkey" FOREIGN KEY (playerone) REFERENCES public."user"(username) NOT VALID;


--
-- TOC entry 2923 (class 2606 OID 24706)
-- Name: battlelog battlelog_playerTwo_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.battlelog
    ADD CONSTRAINT "battlelog_playerTwo_fkey" FOREIGN KEY (playertwo) REFERENCES public."user"(username) NOT VALID;


--
-- TOC entry 2918 (class 2606 OID 16534)
-- Name: stack card_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.stack
    ADD CONSTRAINT card_id FOREIGN KEY (card_id) REFERENCES public.cards(card_id);


--
-- TOC entry 2921 (class 2606 OID 16571)
-- Name: shop shop_card_id_fkey1; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.shop
    ADD CONSTRAINT shop_card_id_fkey1 FOREIGN KEY (card_id) REFERENCES public.cards(card_id);


--
-- TOC entry 2920 (class 2606 OID 16576)
-- Name: trade trade_give_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.trade
    ADD CONSTRAINT trade_give_id_fkey FOREIGN KEY (give_id) REFERENCES public.cards(card_id) NOT VALID;


--
-- TOC entry 2919 (class 2606 OID 16561)
-- Name: trade trade_wanted_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.trade
    ADD CONSTRAINT trade_wanted_id_fkey FOREIGN KEY (wanted_id) REFERENCES public.cards(card_id);


--
-- TOC entry 2916 (class 2606 OID 16456)
-- Name: friends user_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.friends
    ADD CONSTRAINT user_fk FOREIGN KEY (username) REFERENCES public."user"(username);


--
-- TOC entry 2917 (class 2606 OID 16529)
-- Name: stack username; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.stack
    ADD CONSTRAINT username FOREIGN KEY (username) REFERENCES public."user"(username);


-- Completed on 2021-01-10 14:12:50

--
-- PostgreSQL database dump complete
--

