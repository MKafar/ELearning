import React, {Component} from 'react';
import {Header, Button} from 'semantic-ui-react';
import axios from '../../axios';

import './ExerciseVariantDetails.scss';
import CodeWindow from '../../components/Modules/CodeWindow';
import OpenNewWindow from '../../components/Modules/OpenNewWindow';

class ExerciseVariantDetails extends Component {

    constructor(props) {
        super(props);
        this.state ={
            selectedExerciseVariantID: null,
            selectedVariantContent: '',
            variantNumber: null,
            code: '',
            selectedExerciseID: null,
            showComponent: false,
            htmlString: null,

        }
        this._onButtonClick = this._onButtonClick.bind(this);
        this._onClose = this._onClose.bind(this);
    };

    
     componentWillMount = () => {
         this.setState({selectedExerciseVariantID: this.props.match.params.exerciseVariantID});
         this.loadData(this.props.match.params.exerciseVariantID);
     }
    loadData = (param) => {
        axios.get('/api/Variants/GetById/' + param)
        .then(response => {
            this.setState({variantNumber: response.data.number});
            this.setState({selectedVariantContent: response.data.content});
        }).catch(error =>{
            console.log(error.response);
        })
    }
    componentDidMount = () => {
        this.loadData(this.props.match.params.exerciseVariantID);
        this.setState({selectedExerciseID: this.props.match.params.exerciseDetailsID });
        
    }
    _onButtonClick = () => {
        //console.log("Kod:"+this.state.code);
        this.setState({showComponent: true});
        
    }
    _onClose = () => {
        this.setState({showComponent: false});
    }

    getvariantcode = (dataFromCode) =>{
        this.setState({code: dataFromCode});

    }

    sendCodeHandler = () => {
        const inputVariantNumber = this.state.variantNumber;
        axios.put("/api/Variants/Update", {
            id: this.state.selectedExerciseVariantID,
            number: inputVariantNumber,
            exerciseid:  this.state.selectedExerciseID,
            content: this.state.code
        })
            .then(response => {
                console.log(response.data);
            })
            .catch(error => {
                console.log(error.response);
                alert("Nie można dodać treści!")
            })
    }

    render() {
        //zmienianie string na html
        // const htmlString = '<div>Hello World</div>';
        // const v = 6;
        // function createMarkup() {
        //     return {__html: htmlString};
        //   }
       


        return (
            <div className='variantcontainer'>
                <div className='variantCodingContainer'>
                    <Header size='large'>Wariant: {this.state.variantNumber}</Header>
                    {/*<div dangerouslySetInnerHTML={createMarkup()} />*/}
                    <div className="variantCodingContent">
                    {
                        this.state.selectedVariantContent ? <CodeWindow getData={this.getvariantcode} changeModeHTML={true} code={this.state.selectedVariantContent} /> 
                        : null
                    }
                        
                        <div className="variantCodingButtons">
                            <Button primary onClick={this.sendCodeHandler} >Dodaj</Button>
                           <Button onClick={this._onButtonClick} >Podejrzyj</Button>
                           {
                            this.state.showComponent ?  
                               <OpenNewWindow close={this._onClose} htmlCode={this.state.selectedVariantContent}  />
                                : null
                           }
                        </div>

                    </div>

                </div>
            </div>

        );
    }
}

export default ExerciseVariantDetails;