using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace WP
{
    public class GamePipelinePlay : GamePipelineBase
    {
        public override void Draw()
        {
            var roleLogics = EntityManager.Instance.GetTypeEntity("RoleLogic");
            foreach (var roleLogicEntity in roleLogics)
            {
                var roleLogic = roleLogicEntity as RoleLogic;
                if(roleLogic == null)
                    continue;
                GUILayout.BeginHorizontal();
                GUI.enabled = roleLogic != GameAllInfo.SelfRole;
                if (GUILayout.Button(String.Format("Logic:{0},{1} | View:{2},{3}", 
                        roleLogic.id, roleLogic.pos, roleLogic.viewEntity.id, roleLogic.viewEntity.pos)))
                {
                    GameAllInfo.SelfRole = roleLogic;
                }

                GUI.enabled = true;
                GUILayout.EndHorizontal();
            }
            GUILayout.BeginHorizontal();
            var szSkillID = GUILayout.TextField(iSkillID.ToString());
            iSkillID = int.Parse(szSkillID);
            if (GUILayout.Button("释放技能"))
            {
                
            }
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            var szBuffID = GUILayout.TextField(iBuffID.ToString());
            iBuffID = int.Parse(szBuffID);
            if (GUILayout.Button("添加buff"))
            {
                GameAllInfo.SelfRole.AddBuff(0);
            }
            GUILayout.EndHorizontal();
            if (GUILayout.Button("打印当前选中角色信息"))
            {
                Debug.LogError(string.Format("ID:{0},Pos:{1},BuffCount:{2}", 
                    GameAllInfo.SelfRole.id, GameAllInfo.SelfRole.pos, GameAllInfo.SelfRole.lBuffs.Count));
            }
            
            
            GUILayout.Label("WASD:移动");
            if (GUILayout.Button("添加角色"))
            {
                var role = EntityManager.Instance.MakeEntity<RoleLogic>();
                GameUtils.ShowLog("下面我来自我介绍一下");
                role.Name = "李四";
                role.BodyStrength = UnityEngine.Random.Range(0, GameConst.MaxStrength);
                role.FaceStrength = UnityEngine.Random.Range(0, GameConst.MaxStrength);
                role.VoiceStrength = UnityEngine.Random.Range(0, GameConst.MaxStrength);
                role.HandStrength = UnityEngine.Random.Range(0, GameConst.MaxStrength);
                role.FootStrength = UnityEngine.Random.Range(0, GameConst.MaxStrength);
                role.Ready();
            }
        }

        private int iSkillID = 0;
        private int iBuffID = 0;

        public override void Update()
        {
            base.Update();
            InputManager.Instance.Update();
        }
    }
}
