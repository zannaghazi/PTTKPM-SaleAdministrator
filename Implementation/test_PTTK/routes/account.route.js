var express = require('express');
var userModel = require('../model/user.model');

var router = express.Router();

router.get('/', (req, res, next) => {
  res.render('account/login');
})

router.get('/register', (req, res, next) => {
    res.render('account/register',{message:true});
})

router.post('/register',async (req, res, next) => {
  var entity = {
    username: req.body.username,
    password: req.body.password,
    name: req.body.FirstName+req.body.LastName,
    role: 0
  }
  let user =await userModel.validate(req.body.username);
  if(user.length===0){
    await userModel.add(entity);
    res.redirect('/');
  }else{
    res.render('account/register',{message:false});
  }

  router.get('/logout', function (req, res) {
    req.logout();
    res.redirect('/');
});
})

module.exports = router;
