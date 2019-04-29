using DAL;
using Entity;
using System.Collections.Generic;
namespace BLL
{
    public class RoomManageBLL
    {
        private   RoomManageDAL room = new RoomManageDAL();
        /// <summary>
        /// 会议室
        /// </summary>
        /// <returns></returns>
        public List<ConferenceRoomManagement> GetRooms()
        {
            return room.getRooms();
        }
        /// <summary>
        /// 会议室邀请人
        /// </summary>
        /// <returns></returns>
        public List<User> RoomPeople(string s)
        {
            return room.RoomsPeople(s);
        }
            /// <summary>
            /// 动态加载会议室数据
            /// </summary>
            /// <returns></returns>
            public List<ConferenceManagement> Room_getCha()
        {
            return room.Room_getCha();
        }
        //根据id 查询会议室信息:Rooms_Content
        public ConferenceManagement RoomsContents_getCha(int id)
        {
            return room.RoomsContent_getCha(id);
        
}


        /// <summary>
        /// 会议室审核保存按钮
        /// </summary>
        /// <returns></returns>
        public bool RoomExmin_Baoc(ConferenceManagement management)
        {
            return room.RoomExmin_baoc(management);
        }

        /// <summary>
        /// 会议室申请保存按钮
        /// </summary>
        /// <returns></returns>
        public bool RoomApplay_baoc(ConferenceManagement management)
        {
            return room.RoomApplay_baoc(management);

        }
        /// <summary>
        /// 工作单创建修改按钮
        /// </summary>
        /// <returns></returns>
        public bool ROOMS_Update(ConferenceManagement room)
        {
            RoomManageDAL b = new RoomManageDAL();
            var a = b.ROOM_Update(room);
            if (a > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
