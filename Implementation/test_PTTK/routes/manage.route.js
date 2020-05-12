var express = require('express');
var productModel = require('../model/product.model');

var router = express.Router();

var bodyParser = require('body-parser');

var urlencodedParser = bodyParser.urlencoded({ extended: false })

router.get('/product', async (req, res, next) => {
  let list = await productModel.all();
  res.render('./manage/product_generality', {
    list
  });
})


router.get('/addproduct', async (req, res, next) => {
  let list = await productModel.productNeedAdd();
  res.render('./manage/add_product', {
    list
  });
})

router.post('/addproduct', urlencodedParser, async (req, res, next) => {
  let id = req.body.id;
  let SLNhap = req.body.SLNhap;
  let SLCLai = req.body.SLCLai;
  let entity = [];
  for(let i=0; i<id.length ;i++){
    entity.push({id: id[i],amount:parseInt(SLNhap[i])+parseInt(SLCLai[i]) })
  }
  console.log("entity",entity)
  entity.map(async i=>{
     await productModel.update(i)
   })

   //Ten NV nhap Hang , ly do ,... 
   // can them bang de insert
})

module.exports = router;
