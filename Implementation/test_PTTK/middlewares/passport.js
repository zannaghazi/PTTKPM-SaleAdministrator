var passport = require('passport');
var LocalStrategy = require('passport-local').Strategy;
var usertModel = require('../model/user.model');

module.exports = function(app) {
    app.use(passport.initialize())
    app.use(passport.session())
    passport.use(new LocalStrategy(async (username, password, done) => {
        let user = await usertModel.single(username,password);
        if(user.length===0){
            return done(null, false); //, { message: 'Sai Mật Khẩu hoặc username' }
        }else{
            return done(null, user[0]);
        }
    }))
    passport.serializeUser((user, done) => {
        done(null, user)
    })
    passport.deserializeUser(async(user, done) => {
        let u = await usertModel.single(user.username,user.password);
        if(u.length===0){
            return done(null, false);
        }else{
            return done(null, user);
        }
    })

    //login 
    app.post("/login", passport.authenticate('local', {
        failureRedirect: '/',
        successRedirect: '/product'
    }));
}