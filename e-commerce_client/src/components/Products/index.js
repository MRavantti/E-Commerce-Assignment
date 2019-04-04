import React, { Component } from 'react';
import './Products.css';
class Products extends Component {
  state = {
      products: [],
      guid: []
    }

    componentDidMount() {
      this.fetchApi();
      this.fetchCartGuid();
    }

    fetchApi = () => {
      const api = 'http://localhost:5000/api/products';

      fetch(api)
      .then(res => res.json())
      .then(item =>{
        this.setState({
          products: item
        })
      })
    }

    fetchCartGuid = () => {
      const guid = 'http://localhost:5000/api/myGuid';

      fetch(guid)
      .then(res => res.json())
      .then(guid =>{
        this.setState({
          guid: guid
        })
        localStorage.setItem("myGuid", guid)
      })
    }



    handleSubmit(e){
        e.preventDefault();

        const id = e.target[0].value;

       let guid = localStorage.getItem("myGuid")
       
      const send = {Cart_guid: guid, Product_id: id, Quantity: 1 }
                  fetch(`http://localhost:5000/api/cartitems`, {
                  headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                  },
                  method: 'POST',
                  body: JSON.stringify(send),
                })

        console.log(send)
    }



    render() {
      return (
        <div className="productsContainer">
          {this.state.products.map((item, key) =>
            <div className="productBox" key={key}>
              <img className="img" src={item.image_url} alt="LOL" />
                <h2>{item.name} </h2>
                <div className="info">
                <p className="description">{item.description} </p>
                </div>
                <p>{item.price} SEK </p>
              <div>
                <form onSubmit={this.handleSubmit} action="index.html">
                   <input type="hidden" name="id" value={item.id} />
                   <input type="hidden" name="cart_guid" value={this.state.guid} />
                   <button type="submit" className="product-button">Add to cart</button>
                </form>

              </div>
            </div>
          )}
        </div>
      );
    }


}

export default Products;