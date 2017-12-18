var mysql = require('mysql');

function createDBConnection(){
  return mysql.createConnection({
    host : 'brunobcf.me',
    user : 'ami',
    password: 'ami',
    database: 'enermon'
  });
}

module.exports = function(){
  return createDBConnection;
}
