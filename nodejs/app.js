var SerialPort = require('serialport');
var moment = require('moment');
var port = new SerialPort('/dev/ttyUSB0', {
  baudRate: 9600
});
var express = require('express');
var load = require('express-load');
var app = express();

load('infra', {cwd: 'app'}).into(app);
var connection = app.infra.connectionFactory();

const Readline = SerialPort.parsers.Readline;
const parser = port.pipe(new Readline({ delimiter: '\r\n' }));

//port.pipe(parser);
parser.on('data', function (data) {
  var sensor = JSON.parse(data);
  if (sensor.type == 'Temperature'){
    connection.query("INSERT INTO temp (value, time, id) VALUES ('"+(sensor.value/sensor.scale)+"','"+moment().unix()+"','"+sensor.sensorid+"')",function (err,result){
      if (err)
        console.log(err);
      else {
        console.log("Sensor read and data recorded to database");
      }
    });
  }
  if (sensor.type == 'Humidity'){
    connection.query("INSERT INTO hum (value, time, id) VALUES ('"+(sensor.value/sensor.scale)+"','"+moment().unix()+"','"+sensor.sensorid+"')",function (err,result){
      if (err)
        console.log(err);
      else {
        console.log("Sensor read and data recorded to database");
      }
    });

  }
//console.log(sensor.sensorid);
});
