use knjiznica;

select top 10 percent * from autor;

select distinct ime from autor
where ime not like '%k%'
and ime like 'z%'
and ime not like '%a%'
order by ime;

select * from izdavac;

select * from mjesto where postanskiBroj like '31%';