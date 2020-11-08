import React from "react"

class SeeFeedbacks extends React.Component {

    constructor(){
        super()
        this.state={
            feedbacks : []
        }
    }


    componentDidMount(){
        const url="http://localhost:51916/appreviewfeedback"
        fetch(url,{
            method: "GET",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                'dataType': 'json'
                },
            })
            .then(response => response.json())
            .then(responseJSON => {
                alert(responseJSON) 
                this.setState({feedbacks : responseJSON})
            })
        
    }

    render() {
        let array = [];
        for(let i = 0; i < this.state.feedbacks.length; i++) {
          array.push(
          <div key={i} item={this.state.feedbacks[i]}><label>{"ID: " + i + ", Text: " + this.state.feedbacks[i].reviewText}</label></div>
          );
        }
        
        return (
            <div>
                { array }
            </div>
        );
    }

}

export default SeeFeedbacks