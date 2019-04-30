using DAL;
using Entity;
using System.Collections.Generic;
namespace BLL
{
    public class RoomManageBLL
    {
        private RoomManageDAL room = new RoomManageDAL();
        /// <summary>
        /// 会议室
        /// </summary>
        /// <returns></returns>
        public List<ConferenceRoomManagement> GetRooms()
        {
            return room.getRooms();
        }
        /// <summary>
        /// 会议室管理资源图
        /// </summary> 
        /// <returns></returns>
        public List<ConferenceManagement> Select_infroations()
        {
            return room.Select_infroation();
        }
        /// <summary>
        /// 会议室管理资源图按条件查询
        /// </summary>
        /// <returns></returns>
        public List<ConferenceManagement> Select_infroationName(string name)
        {
            return room.Select_infroationName(name);

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

        /// <summary>
        /// 根据会议名称查询会议室数据
        /// 根据会议室名称查询会议室数据
        /// </summary>
        /// <returns></returns>
        public List<ConferenceManagement> Room_getChaName(string Name_Meeting, string Conference_Room_Name)
        {
            return room.Room_getChaName(Name_Meeting, Conference_Room_Name);
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
        /// 会议室创建修改按钮
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

        /// <summary>
        /// 会议室预约人：Rooms_Information
        /// </summary>
        /// <returns></returns>
        public List<User> Rooms_Informations_Orders(string DepartName)
        {


            return room.Rooms_Informations_Order(DepartName);
        }

        public List<User> Rooms_Informations_OrderSelects()
        {
            return room.Rooms_Informations_OrderSelects();
        }
    }
}
