import React from "react"
import Feedback from "./Feedback"
import axios from "axios"

class SeeFeedbacks extends React.Component {

    constructor(){
        super()
        this.state={
            feedbacks : []
        }
    }

    componentDidMount() {
        var url
        if(this.props.onlyPublished==="true")                       /* Visual studio IIS server port: "http://localhost:51916/reviews"  */
            url="http://localhost:51916/reviews/published" 
        else
            url="http://localhost:51916/reviews"

            axios.get(url)
            .then(response => {
                this.setState({feedbacks : response.data})
            })
            .catch(error => {
                console.log(error)
            })
    }

    render() {
        let array = [];
        for(let i = 0; i < this.state.feedbacks.length; i++) {
          array.push(
          <div key={this.state.feedbacks[i].appReviewId} item={this.state.feedbacks[i]}><Feedback feedbackData={this.state.feedbacks[i]}/> </div>
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