import _ from 'lodash'

import React, { Component } from 'react'
import { Search, Grid } from 'semantic-ui-react'
import axios from '../../axios';

class SearchExercise extends Component {

    state = {
        source: []
    }

    componentDidMount () {
        axios.get('/api/Exercises/GetAll')
        .then(response => {
            this.setState({source: response.data.exercises})
        });
    }

    componentWillMount() {
        this.resetComponent()
    }

    resetComponent = () => (
        this.setState({ isLoading: false, results: [], value: '' })
    )

    handleResultSelect = (e, { result }) => {

        this.setState({ value: result.title });

        this.props.selectvalue(result.id);
        
    }

    handleSearchChange = (e, { value }) => {
        this.setState({ isLoading: true, value })

        setTimeout(() => {
            if (this.state.value.length < 1) return this.resetComponent()

            const source = this.state.source;
            const re = new RegExp(_.escapeRegExp(this.state.value), 'i')
            const isMatch = result => re.test(result.title)

            this.setState({
                isLoading: false,
                results: _.filter(source, isMatch),
            })
        }, 300)
    }

    render() {
        const { isLoading, value, results } = this.state;
        

        return (
            <Grid>
                <Grid.Column width={6}>
                    <Search
                        loading={isLoading}
                        onResultSelect={this.handleResultSelect}
                        onSearchChange={_.debounce(this.handleSearchChange, 500, { leading: true })}
                        results={results}
                        value={value}
                        {...this.props}
                    />
                </Grid.Column>
                {/* <Grid.Column width={10}>
                    <Segment>
                        <Header>State</Header>
                        <pre style={{ overflowX: 'auto' }}>{JSON.stringify(this.state, null, 2)}</pre>
                        <Header>Options</Header>
                        <pre style={{ overflowX: 'auto' }}>{JSON.stringify(source, null, 2)}</pre>
                    </Segment>
                </Grid.Column> */}
            </Grid>
        )
    }
}

export default SearchExercise;