import React from "react"
import { Button } from "reactstrap"
import 'bootstrap/dist/css/bootstrap.css';
import {Redirect} from "react-router-dom"


class FeedbackForm extends React.Component{

constructor(){
    super()
    this.state={
        Comment : "",
        Anonymous : false,
        Publishable : false,
        Published : false,
        Redirect : false
    }
    this.handleChange=this.handleChange.bind(this)
    this.handleSubmit=this.handleSubmit.bind(this)
}


handleChange(event){
    const {name, value, type, checked} = event.target
    type === "checkbox" ? this.setState({ [name]: checked }) : this.setState({ [name]: value })
}

handleSubmit = (event) => {
    event.preventDefault()

    if(this.state.Comment !== "")
    {
        const appReviewFeedbackInfo = {
            reviewText : this.state.Comment,
            anonymous : this.state.Anonymous,
            publishable : this.state.Publishable,
            published : false
        }

        alert('Form submitted');
        const url="http://localhost:51916/reviews"
        fetch(url,{
            method: "POST",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                },
            body: JSON.stringify(appReviewFeedbackInfo)
            })
            
            this.setState({Redirect : true})
    } else {
        alert("Please fill the form before submitting")
    }
    
}

render(){


return(
<div className={this.props.class}>
    {this.state.Redirect ? <Redirect to="/"/> : null}
    <form onSubmit={this.handleSubmit}>
        <table>

        <tr>
            <td>
            <label height="1px" >Comment </label>
            </td>
            <td>
            <textarea 
                type="text" 
                value={this.state.Comment} 
                name="Comment" 
                placeholder="Comment" 
                onChange={this.handleChange} 
                width="500"
                height="250"
            />
            </td>
        </tr>
        <tr>
            <td>
            <label>Anonymous </label> 
            </td>
            <td>
            <input type="checkbox"  onChange={this.handleChange}  name="Anonymous"/>
            </td>
        </tr>
        
 
        <tr>
                <td>
            <label>Publishable </label>
                </td>
            <td>
            
            <input type="checkbox" onChange={this.handleChange} name="Publishable"/>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            <Button color="primary" style={{margin : "1vh"}}>Submit Feedback</Button>
            </td>
        </tr>

        </table>
    </form>

</div>)


}

}

export default FeedbackForm