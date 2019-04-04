import React, { Component } from 'react';
import "./Cart.css"

class Cart extends Component {
  state = {
    cart: [],
    products: [],
    myGuid:  localStorage.getItem("myGuid")
  }
  componentDidMount() {
    this.fetchCart();

  }
  
  
  fetchCart = () => {
    const cart = `http://localhost:5000/api/Cart/${this.state.myGuid}`;
    
    fetch(cart)
    .then(res => res.json())
    .then(cart =>{
      this.setState (
        {
          cart: cart
        }
      )
    }
  )
}    

render() {
  return (
    <div className="cart-container">
      <h4>Cart</h4>
      <div className="lol">
        {this.state.cart.map((item, key) =>
          <div className="cart-box" key={key}>
            <img className="cart-img" src={item.image_url} alt="LOL" />
            <h2>{item.name} </h2>
            <div className="info">
              <p className="description">{item.description} </p>
            </div>
            <p>{item.price} SEK </p>
            
          </div>
        )}
      </div>
    </div>
  );
}


}

export default Cart;