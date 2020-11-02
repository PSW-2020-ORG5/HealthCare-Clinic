import React from "react"
import { Label,Button } from "reactstrap"

class FeedbackForm extends React.Component{

constructor(){
    super()
    this.state={
        Quality : "",
        Security : "",
        Kindness : "",
        Professionalism : "",
        Comment : "",
        Anonymous : false,
        Publishable : false
    }
    this.handleChange=this.handleChange.bind(this)
}

handleChange(event){
    const {name, value, type, checked} = event.target
    type === "checkbox" ? this.setState({ [name]: checked }) : this.setState({ [name]: value })

}

handleSubmit = (event) => {
    event.preventDefault()

    const surveyInfo = {
        Quality : this.state.Quality,
        Security : this.state.Security,
        Kindness : this.state.Kindness,
        Professionalism :this.state.Professionalism,
        Comment : this.state.Comment,
        Anonymous : this.state.Anonymous,
        Publishable : this.state.Publishable,
    }

    alert('A form was submitted ');
    const url="http://localhost:51916/surveys"
    fetch(url,{
        method: "POST",
        headers: { "Content-type" : "application/json"},
        body: JSON.stringify(surveyInfo)})
        .then(response => response.json())
        .then(res => {
            if(res)
            {
                //success
                //this.setstate({this.state.message = success or smth})
            }
        } )
    
}

render(){


return(
<div>
    <form onSubmit={this.handleSubmit}>
        <table>
        <tr>
            <td>
            <Label>Quality </Label>
            </td>
            <td>
            <select 
            value={this.state.Quality}
                onChange={this.handleChange}
                name="Quality"                >
                <option value="">-- Select an option --</option>
                <option value="terrible">Terrible</option>
                <option value="bad">Bad</option>
                <option value="good">Good</option>
                <option value="great">Great</option>
                <option value="excellent">Excellent</option>
            </select>
            </td>
        </tr>

        <tr>
            <td>
            <Label>Security </Label>
            </td>
            <td>
            <select 
            value={this.state.Security}
                onChange={this.handleChange}
                name="Security"                >
                <option value="">-- Select an option --</option>
                <option value="terrible">Terrible</option>
                <option value="bad">Bad</option>
                <option value="good">Good</option>
                <option value="great">Great</option>
                <option value="excellent">Excellent</option>
            </select>
            </td>
        </tr>

        <tr>
            <td>
            <Label>Kindness </Label>
            </td>
            <td>
            <select 
            value={this.state.Kindness}
                onChange={this.handleChange}
                name="Kindness"                >
                <option value="">-- Select an option --</option>
                <option value="terrible">Terrible</option>
                <option value="bad">Bad</option>
                <option value="good">Good</option>
                <option value="great">Great</option>
                <option value="excellent">Excellent</option>
            </select>
            </td>
        </tr>

        <tr>
            <td>
            <Label>Professionalism </Label>
            </td>
            <td>
            <select 
            value={this.state.Professionalism}
                onChange={this.handleChange}
                name="Professionalism"                >
                <option value="">-- Select an option --</option>
                <option value="terrible">Terrible</option>
                <option value="bad">Bad</option>
                <option value="good">Good</option>
                <option value="great">Great</option>
                <option value="excellent">Excellent</option>
            </select>
            </td>
        </tr>

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
            <Label>Anonymous </Label> 
            </td>
            <td>
            <input type="checkbox" name="Anonymous"/>
            </td>
        </tr>
        
 
        <tr>
                <td>
            <Label>Publishable </Label>
                </td>
            <td>
            
            <input type="checkbox" name="Publishable"/>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            <Button color="primary">Submit Survey</Button>
            </td>
        </tr>

        </table>
    </form>

</div>)


}


}




export default FeedbackForm