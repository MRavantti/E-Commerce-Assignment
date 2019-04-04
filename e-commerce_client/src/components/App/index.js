import React, { Component } from 'react';
import './App.css';
import Products from '../Products'
import Cart from '../Cart'
import Modal from 'react-modal';

class App extends Component {
	
	
	constructor () {
		super();
		this.state = {
			showModal: false,
			myGuid:  localStorage.getItem("myGuid"),
			order: []
		};
		
		this.handleOpenModal = this.handleOpenModal.bind(this);
		this.handleCloseModal = this.handleCloseModal.bind(this);
	}
	
	handleOpenModal () {
		this.setState({ showModal: true });
		this.fetchOrder()
	}
	
	handleCloseModal () {
		this.setState({ showModal: false });
	}
	
	fetchOrder() {
      const cart = `http://localhost:5000/api/orderitems/${this.state.myGuid}`;

      fetch(cart)
      .then(res => res.json())
      .then(order =>{
        this.setState (
          {
          order: order
          }
        )
				console.log(order)
      }
    )
	}
	
	handleSubmit(e) {

		e.preventDefault();
		
		const name = e.target[0].value;
		const adress = e.target[1].value;
		const zipcode = e.target[2].value;
		const city = e.target[3].value;
		const email = e.target[4].value;
		const cart_guid = e.target[5].value;
		
		const send = {Name: name, Adress: adress, Zipcode: zipcode, City: city, Email: email, Cart_guid: cart_guid}
		fetch(`http://localhost:5000/api/customer`, {
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
			<div className="App">
				
				<h1>Welcome to the Shop Hoax Imaginative Tugboats!</h1>
				
				<button className="cart" onClick={this.handleOpenModal}>Cart</button>
				
				<Products/>
				
				<Modal 
					isOpen={this.state.showModal}
					contentLabel="onRequestClose Example"
					onRequestClose={this.handleCloseModal}
					>
					
					<Cart></Cart>
					
					<div className="order-form">
						
					<form onSubmit={this.handleSubmit} action="index.html">
						
						Name: 
						<input type="text" name="name" />
						Adress:
						<input type="text" name="adress" />
						ZipCode:
						<input type="text" name="zipcode" />
						City:
						<input type="text" name="city" />
						Email:
						<input type="text" name="email" />
						
						<input type="hidden" name="cart_guid" value={this.state.myGuid}/>
						
						<p>{this.state.order.total_price}</p>
				
						<button type="submit" className="order-button">Order</button>
						
					</form>
				</div>
				
					<button onClick={this.handleCloseModal}>Close Cart</button>
					
				</Modal>
				
			</div>
		);
	}
}

export default App;