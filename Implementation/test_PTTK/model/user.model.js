var db = require('../utils/db');

module.exports = {
  all: () => {
    return db.load('select * from user');
  },

  single: (username,password) => {
    return db.load(`select * from user where username ="${username}" and password = "${password}"`);
  },
  
  validate: (username) => {
    return db.load(`select * from user where username ="${username}"`);
  },

  add: entity => {
    return db.add('user', entity);
  },

  update: entity => {
    return db.update('user', 'id', entity);
  },

  delete: id => {
    return db.delete('user', 'id', id);
  },
};
