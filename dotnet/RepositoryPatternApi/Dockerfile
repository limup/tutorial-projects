#Create MySQL Image for JSP Tutorial Application
FROM mysql
MAINTAINER limup@outlook.com

ENV MYSQL_ROOT_PASSWORD limupPass
ADD jsp_backup.sql /docker-entrypoint-initdb.d

EXPOSE 3306