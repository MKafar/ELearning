import React, { Component } from 'react';
import { Header } from 'semantic-ui-react';
import axios from '../../axios';

import './SubjectGroups.scss';
import ModalAddGroup from '../../components/Modules/ModalAddGroup'
import DetailList from '../../components/Modules/DetailList'

class SubjectGroups extends Component {

    state = {
        exerciseGroups: [],
        selectedGroupID: null,
        selectedGroupName: ''
    }

    loadData = () => {
        // axios.get('/api/Exercises/GetAllVariantsById/' + this.state.selectedGroupID)//////////////
        // .then(response => {
        //     this.setState({ exerciseGroups: response.data.variants });
        // }).catch(error => {
        //     console.log(error.response);
        // });

        axios.get('/api/Sbjects/GetById/' + this.state.selectedGroupID)
        .then(response => {
            this.setState({ selectedGroupName: response.data.title });
        }).catch(error => {
            console.log(error.response);
        });
        
    }

    componentDidMount = () => {
        this.loadData();
    }
    componentWillMount = () => {

        this.setState({selectedGroupID: this.props.match.params.subjectGroupID}); //subjectGroupID
    }

    detailsHandler = (exerciseGroupID) => {
        this.props.history.push('/subjects/' + this.props.match.params.subjectGroupID + '/' + exerciseGroupID);
    }

    removeHandler = (groupRemoveID) => {
        axios.delete('/api/Variants/Delete/'+ groupRemoveID)
            .then(response => {
                console.log(response);
                this.loadData();
            }).catch(error => {
                console.log(error.response);
                alert("Nie można usunąć grupy");
            });
    }

    render() {


        return (
            <div className="SubjectGroups">
                <div>
                    <Header size='huge'>
                    {this.state.selectedGroupName}
                    </Header>

                    <ModalAddGroup selectedGroupID={this.state.selectedGroupID} updateData={this.loadData} /> 

                    <div className="groups">

                        {this.state.exerciseGroups.map((group) => {
                            return <DetailList
                                visibledetail={true}
                                visibledelete={true}
                                key={group.id}
                                name={group.name}
                                text={'Grupa: '} 
                                detailsClicked={()=> this.detailsHandler(group.id)}
                                removeClicked={()=>this.removeHandler(group.id)}
                                />
                        })}
                    </div>
                </div>
            </div>
        );
    }
}

export default SubjectGroups;