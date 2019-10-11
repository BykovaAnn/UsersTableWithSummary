# UsersTableWithSummary

Test Task. Contains .NETCore Web API project and main files of Angular 8 project.
<br><br>
Web API project works on localhost:58575. <br>
Database is created with CodeFirst on local Sql Server (.\SQLEXPRESS). For its creation run commamds in package manager: <br>
1. Add-Migration MigrationName<br>
2. Update-Database<br>

Angular project works on default localhost:4200. It doesn't contain node_modules folder because of GitHub restrictions, that why it should be intstalled with npm commands.<br>
Also for Angular project run npm command: <br>
ng serve -o<br>
<br>
***Task***
1. Create table "Users" in the database with the next fields:<br>
○ Id (int, primary key, autoincrement)<br>
○ Name (string, max length = 500)<br>
○ Active (boolean, default value = false)<br>
2. Fill this table with data (10 rows will be enough).<br>
3. Create web application to display this table on a web page.<br>
○ Id and Name fields must be represented as is, just display their values.<br>
○ Active field must be represented by a checkbox, checked on not checked depending on a value.<br>
○ Each time when user checks or unchecks a checkbox “Active” of any single row, backend request must be triggered to save this change into the database.<br>
4. Add a button below the table. On click - pop-up with total User count and active User count must be displayed.<br>
