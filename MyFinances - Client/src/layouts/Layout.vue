<template>
 <div id="template">
        <SideBar/>
        <div id="right-div">
            <router-view/>
        </div>
    </div>
</template>

<script>
import SideBar from '@/layouts/SideBar.vue'
export default{
    components:{
        SideBar
    }
}
</script>

<style scoped>
#template{
    display: flex;
}

#right-div{
    width: 100%;
    padding-right: 25px;
    margin-left: 250px;
    display: flex;
    flex-direction: column;
}
</style>