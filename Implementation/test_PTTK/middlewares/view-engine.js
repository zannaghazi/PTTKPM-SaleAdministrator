var express = require("express");

module.exports = function (app) {

app.set("view engine", "ejs");
app.set("views", "./view");
}