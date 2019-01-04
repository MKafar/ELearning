import React, { Component } from 'react';
import { Header } from 'semantic-ui-react';
import axios from '../../axios';

import './ExerciseVariant.scss';
import ModalAddVariant from '../../components/Modules/ModalAddVariant'
import DetailList from '../../components/Modules/DetailList'

class ExerciseVariant extends Component {
    constructor(props) {
        super(props);
    };

    state = {
        variants: [],
        selectedExerciseID: null
    }

    loadData = () => {
        axios.get('/api/Exercises/GetAlVariantsById' + this.state.selectedExerciseID)
        .then(response => {
            console.log(response)
            //this.setState({ exerciseViariants: response.data.variants });

        }).catch(error => {
            console.log(error.response);
        });
    }

    componentDidMount = () => {
        console.log("Zadanie:"+this.state.selectedExerciseID);
        this.loadData();
    }
    componentWillMount = () => {
        this.setState({selectedExerciseID: this.props.match.params.exerciseDetailsID});
    }

    editHandler = () => {
        console.log('Edit');
    }
    saveHandler = () => {
        console.log('Zapisz');
    }

    detailsHandler = (exerciseVariantID) => {
        this.props.history.push('/exercises/' + this.props.match.params.exerciseDetailsID + '/' + exerciseVariantID);
    }

    removeHandler = (exerciseRemoveID) => {
        console.log('Usuń', exerciseRemoveID);
    }

    render() {


        return (
            <div className="ExerciseVariant">
                <div>
                    <Header size='huge'>
                    Jakiś długi tytuł bardzo długi tytuł
                    {/* <Button.Group> 
                        <Button icon onClick={this.editHandler}>
                            <Icon name='edit' />
                        </Button>
                        <Button icon onClick={this.saveHandler}>
                            <Icon name='save' />
                        </Button>
                    </Button.Group>  */}
                    </Header>

                    <ModalAddVariant updateData={this.loadData} /> 

                    <div className="variants">

                        {this.state.variants.map((variant) => {
                            return <DetailList
                                visibledetail={true}
                                visibledelete={true}
                                key={variant.id}
                                number={variant.number}
                                text={'Wariant: '} 
                                detailsClicked={()=> this.detailsHandler(variant.id)}
                                removeClicked={()=>this.removeHandler(variant.id)}
                                />
                        })}
                    </div>
                </div>
            </div>
        );
    }
}

export default ExerciseVariant;