var express = require('express');
var path = require('path');
var fs =require('fs');
const { render } = require('ejs');
const alert = require('alert');
var jsdom = require("jsdom");
var JSDOM = jsdom.JSDOM;
global.document={execCommand(){}};
var app = express();
var url = require('url');
var session=require('express-session');

var page;

// view engine setup
app.set('views', path.join(__dirname, 'views'));
app.set('view engine', 'ejs');

app.use(express.json());
app.use(express.urlencoded({ extended: false }));
app.use(express.static(path.join(__dirname, 'public')));

var User ;
app.use(session({
      
   resave:false,
   saveUninitialized:true,
   secret:'Mat5oshesh Ya Bro',
}));


app.get('/' ,function(req,res){
  res.render('login')

});

app.get('/searchresults' ,function(req,res){
  if(User.name!=undefined)
  res.render('searchresults',{products:""})

});

/*var x ={name:"Mariam", age: 20, username:"mariam237", password:"abc123"};
var y = JSON.stringify(x);
fs.writeFileSync("users.json", y);
var data=fs.readFileSync("users.json");
var z = JSON.parse(data);
console.log(z);*/

app.post('/' ,async function(req,res){
  var x= req.body.username;
  var y= req.body.password;
  if(req.session.User==undefined)
  {
  var a=req;
  var b = res;
  var flag=false;
  User="";
  if(x=="" )
 {
   flag=true;
 }
 if(y=="")
 {
   flag=true;
 }
 if(flag)
 {
   let alert = require('alert');
    alert("Please enter your username and password or register instead");
   
    res.render('login');
 }
 else{
  var f = await Login(x,y);
  console.log(f);
  if(f)
  {
    User=req.session;
    User.name=x;
    User.page="";
    User.cart=[];
     res.redirect('/home' );

  }
  else
  {
    let alert = require('alert');
    alert("The username or password is invlaid");
    res.render('login');
    
  }
}
  }
  else if (User.name){
    res.redirect('/home');

  }
});

app.get('/registration' , function(req,res){
  res.render('registration',{title: "registration"})
});

app.post('/register' , async function(req,res){
  var x= req.body.username;
  var y= req.body.password;
  if(x=="" || y=="")
  {
    let alert = require('alert');
    alert("please enter valid information !!");
    res.render('registration');
  }
  else {
     var x = await Register(x,y).catch(console.error);
     if(x){
       res.redirect('/');
     }
     else
     {
       let alert = require('alert');
      alert("This Username is already taken.");
      res.render('registration');
     }

  }

});
app.post('/cart' , async function(req,res){
  var { MongoClient } = require('mongodb');
  var uri = "mongodb+srv://Mariam237:mero237@cluster0.bcu99.mongodb.net/firstdb?retryWrites=true&w=majority"
  var client = new MongoClient(uri, {useNewUrlParser: true , useUnifiedTopology: true });
  await client.connect();
  var output =await client.db('firstdb').collection('secondcollection').find().toArray();
  var record="";
  var index=0;
  User=req.session;
  for(var i=0;i<output.length;i++)
  {
    if(output[i].username==User.name)
    {
      record=output[i];
      index=i;
    }
  }
  var array=output[index].cart;
  User=req.session;
  User.cart=array;
  res.render('cart',{products: array});
 
});

app.post('/searchresults' , async function(req,res){
  var x = req.body.Search;
  if(x=="")
  {
    let alert =require('alert');
    alert("please enter a valid item");
    res.redirect(req.get('referer'));

  }
  else{

    var array = await Search(x);
    if(array.length!=0)
    {
      res.render('searchresults',{products: array});
    }
    else{
      let alert=require('alert');
      alert("ITEM NOT FOUND!!!!!");
      res.redirect(req.get('referer'));
    }
}});


app.get('/home' ,function(req,res){
  User=req.session;
  if(User.name!=undefined)
  res.render('home')
});

async function Login(user,pass){
  var { MongoClient } = require('mongodb');
  var uri = "mongodb+srv://Mariam237:mero237@cluster0.bcu99.mongodb.net/firstdb?retryWrites=true&w=majority"
  var client = new MongoClient(uri, {useNewUrlParser: true , useUnifiedTopology: true });
  var flag=false;
  await client.connect();
  var output =await client.db('firstdb').collection('secondcollection').find().toArray();
  //console.log(output);
  for(var i=0;i<output.length;i++)
  {
    if(output[i].username==user)
    {
      if(output[i].password==pass)
      {
        flag=true;
        break;
      }
    }
  }
  


  client.close();
  return flag;
}
async function Register(user,pass){
  var { MongoClient } = require('mongodb');
  var uri = "mongodb+srv://Mariam237:mero237@cluster0.bcu99.mongodb.net/firstdb?retryWrites=true&w=majority"
  var client = new MongoClient(uri, {useNewUrlParser: true , useUnifiedTopology: true });
  var flag=true;
  await client.connect();
  var output =await client.db('firstdb').collection('secondcollection').find().toArray();
  var cart=[];
  var users = {username:user, password:pass, cart};
  for(var i=0;i<output.length;i++)
  {
    if(output[i].username==user  )
    {
      flag=false;
      break;
    }}
  if(flag)
  {
    await client.db('firstdb').collection('secondcollection').insertOne(users);
    client.close();
  }
  return flag;

};
async function Search(product){
  var arr= [];
  var { MongoClient } = require('mongodb');
  var uri = "mongodb+srv://Mariam237:mero237@cluster0.bcu99.mongodb.net/firstdb?retryWrites=true&w=majority"
  var client = new MongoClient(uri, {useNewUrlParser: true , useUnifiedTopology: true });
  var flag=true;
  var id;
  await client.connect();
  var output =await client.db('firstdb').collection('Products').find().toArray();
  for(var i =0;i<output.length;i++)
  {
    var x =""+output[i].prod;
    console.log(x);
    var y= ""+product;
    console.log(y);
    if((x.toLowerCase().includes(y.toLowerCase())))
    {
      arr.push(x);
      //id=output[i]._id;
    }
  }
  client.close();
  return arr;
  //return id;
}

app.post('/addToCart',async function(req,res){
  User=req.session;
   var item = User.page;
   console.log(item);
   var flag=false;
   var { MongoClient } = require('mongodb');
   var uri = "mongodb+srv://Mariam237:mero237@cluster0.bcu99.mongodb.net/firstdb?retryWrites=true&w=majority"
   var client = new MongoClient(uri, {useNewUrlParser: true , useUnifiedTopology: true });
   await client.connect();
   var output =await client.db('firstdb').collection('secondcollection').find().toArray();
   var record="";
   var index=0;
   for(var i=0;i<output.length;i++)
   {
     if(output[i].username==User.name)
     {
      
       record=output[i];
       index=i;
     }
   }
   var Cart=record.cart;
   for(var i of Cart){
    
     if(i==item){
       flag=true;
     }
   }
   if(flag)
   {
     let alert=require('alert');
     alert("You can't add same object twice");
    
   }
   else{
    await client.db('firstdb').collection('secondcollection').findOneAndUpdate({username:User.name},{$push:{cart:item}});
    client.close();    
    let alert=require('alert');
     alert("Object added successfully"); 
     }
     res.redirect(req.get('referer'));
    

});




app.get('/books' ,function(req,res){
  User=req.session;
  if(User.name!=undefined)
  res.render('books',{title: "books"})
});

app.get('/boxing' ,function(req,res){
   User=req.session;
  if(User.name!=undefined){
  User.page="Boxing Bag";
  res.render('boxing',{title: "boxing"})
  }
});

app.get('/cart' ,function(req,res){
  User=req.session;
  if(User.name!=undefined){
  res.render('cart',{products:User.cart})
  }
});

app.get('/galaxy' ,function(req,res){
  User=req.session;
  if(User.name!=undefined){
  User.page="Galaxy S21 Ultra";
  res.render('galaxy',{title: "galaxy"})}
});

app.get('/iphone' ,function(req,res){
  User=req.session;
  if(User.name!=undefined){
  User.page="iPhone 13 Pro";
  res.render('iphone',{title: "iphone"})}
});

app.get('/leaves' ,function(req,res){
  User=req.session;
  if(User.name!=undefined){
  User.page="Leaves of Grass";
  res.render('leaves',{title: "leaves"})}
});

app.get('/phones' ,function(req,res){
  User=req.session;
  if(User.name!=undefined)
  res.render('phones',{title: "phones"})
});

app.get('/searchresults' ,function(req,res){
  User=req.session;
  if(User.name!=undefined)
  res.render('searchresult',{title: "searchresult"})
});

app.get('/sports' ,function(req,res){
  User=req.session;
  if(User.name!=undefined)
  res.render('sports',{title: "sports"})}
);

app.get('/sun' ,function(req,res){
  User=req.session;
  if(User.name!=undefined){
  User.page="The Sun and Her Flowers";
  res.render('sun',{title: "sun"})}
});

app.get('/tennis' ,function(req,res){
  User=req.session;
  if(User.name!=undefined){
  User.page="Tennis Racket";
  res.render('tennis',{title: "tennis"})}
});

if(process.env.PORT){
 app.listen(process.env.PORT, function(){console.log("Server started")});
}
else{
  
    app.listen(3000, function(){console.log("Server started on port 3000")});
   
}
//app.listen(3000);
