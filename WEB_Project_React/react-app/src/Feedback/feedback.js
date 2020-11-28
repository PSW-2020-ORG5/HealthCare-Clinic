import React, { Component } from 'react';
import axios from 'axios';

class Example extends Component {
    state = { 
        feedbacks: []
    }

    componentDidMount() {
        // ovde saljes get zahtev
        axios.get('localhost:8080.....')
            .then(response => { // ovde dobijas odgovor sa beka
                // setState ce dodeliti vrednost koju si poslala sa beka(to je neki niz vrv)
                // stavice u promenljivu feedbacks, koja se nalazi u state
                this.setState({ feedbacks: response });
            });
    }

    render() {
        let array = [];
        for(let i = 0; i < this.state.feedbacks.length; i++) {
          array.push(
            <div key={i} item={this.state.feedbacks[i]}></div>
          );
        }
        
        return (
            <div>
                { array }
            </div>
        );
    }
}

export default Example;