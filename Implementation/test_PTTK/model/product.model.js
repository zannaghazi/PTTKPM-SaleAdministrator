var db = require('../utils/db');

module.exports = {
  all: () => {
    return db.load('select * from item');
  },
  productNeedAdd :()=>{
    return db.load('SELECT * FROM item where amount<minimum')
  },
  
  single: id => {
    return db.load(`select * from item where id = ${id}`);
  },

  add: entity => {
    return db.add('item', entity);
  },

  update: entity => {
    return db.update('item', 'id', entity);
  },

  delete: id => {
    return db.delete('item', 'id', id);
  },
};
