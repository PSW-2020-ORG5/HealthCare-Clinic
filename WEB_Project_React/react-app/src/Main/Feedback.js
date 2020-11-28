import React from "react"
import "../CSS/Feedbacks.css"
import { Button } from "reactstrap"
import 'bootstrap/dist/css/bootstrap.css';

class Feedback extends React.Component {

render() {
    return(
        <div className="singleFeedbackStyling">

<label style={{fontWeight: "bold"}}>{"Feedback ID:"}</label>            
            <label>&nbsp;{this.props.feedbackData.appReviewId}&nbsp;&nbsp;</label>
            <label style={{fontWeight: "bold"}}>{"Anonymous:"}</label>            
            <label>&nbsp;{this.props.feedbackData.anonymous ? "Yes" : "No"}&nbsp;&nbsp;</label>
            <label style={{fontWeight: "bold"}}>{"Publishable:"}</label>            
            <label>&nbsp;{this.props.feedbackData.publishable ? "Yes" : "No"}&nbsp;&nbsp;</label>
            <label style={{fontWeight: "bold"}}>{"Published:"}</label>            
            <label>&nbsp;{this.props.feedbackData.published ? "Yes" : "No"}&nbsp;&nbsp;</label><br/>
            
            
            <label style={{fontWeight: "bold"}}>{"Text:"}</label>
            <label>&nbsp;{this.props.feedbackData.reviewText}</label><br/>

            { this.props.feedbackData.publishable && !this.props.feedbackData.published ?  <Button color="primary" style={{margin: "1vh"}} >Publish feedback</Button> : null}
            
        </div>

    )

}

}

export default Feedback