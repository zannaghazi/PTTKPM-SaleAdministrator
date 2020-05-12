var express = require('express');
// var moment = require('moment');
// var userModel = require('../models/user.model');

var router = express.Router();

// router.post('/register', (req, res, next) => {
//   var saltRounds = 10;
//   var hash = req.body.password
//   var dob = moment(req.body.dob, 'DD/MM/YYYY').format('YYYY-MM-DD');

//   var entity = {
//     f_Username: req.body.username,
//     f_Password: hash,
//     f_Name: req.body.name,
//     f_Email: req.body.email,
//     f_DOB: dob,
//     f_Permission: 0
//   }

//   userModel.add(entity).then(id => {
//     res.redirect('/account/login');
//   })
// })

router.get('/', (req, res, next) => {
  res.render('account/login');
})

router.get('/register', (req, res, next) => {
    res.render('account/register');
  })

module.exports = router;
